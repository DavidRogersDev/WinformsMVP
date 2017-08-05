using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;

namespace WinFormsMvp.Binder
{
    internal class DefaultCompositeViewTypeFactory : ICompositeViewTypeFactory
    {
        static readonly object compositeViewTypeCacheLock = new object();
        static readonly IDictionary<RuntimeTypeHandle, Type> compositeViewTypeCache = new Dictionary<RuntimeTypeHandle, Type>();

        public Type BuildCompositeViewType(Type viewType)
        {
            var viewTypeHandle = viewType.TypeHandle;

            Type compositeViewType;
            if (compositeViewTypeCache.TryGetValue(viewTypeHandle, out compositeViewType))
            {
                return compositeViewType;
            }

            lock (compositeViewTypeCacheLock)
            {
                compositeViewType = BuildCompositeViewTypeInternal(viewType);
                compositeViewTypeCache[viewTypeHandle] = compositeViewType;
            }

            return compositeViewType;
        }

        internal static Type BuildCompositeViewTypeInternal(Type viewType)
        {
            /*
             * To support composite views, we dynamically emit a type which
             * takes multiple views, and exposes them as a single view of
             * the same interface. It's something like this:
             * 
public class TestViewComposite
    : CompositeView<ITestView>, ITestView
{
    public TestViewModel Model
    {
        get
        {
            return Views.First().Model;
        }
        set
        {
            foreach(var view in Views)
                view.Model = value;
        }
    }
    
    public event EventHandler Searching
    {
        add
        {
            foreach (var view in Views)
            {
                view.Searching += value;
            }
        }
        remove
        {
            foreach (var view in Views)
            {
                view.Searching -= value;
            }
        }
    }
}
             * 
             */

            ValidateViewType(viewType);

            var assemblyName = BuildAssemblyName();
            var assembly = BuildAssembly(assemblyName, AppDomain.CurrentDomain);
            var module = BuildModule(assembly, assemblyName);

            var type = BuildType(viewType, module);

            var properties = DiscoverProperties(viewType);
            BuildProperties(type, viewType, properties);

            var events = DiscoverEvents(viewType);
            BuildEvents(type, viewType, events);

            var compositeViewType = type.CreateType();

            return compositeViewType;
        }

        internal static void ValidateViewType(Type viewType)
        {
            if (!viewType.IsInterface)
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "To be used with shared presenters, the view type must be an interface, but {0} was supplied instead.",
                    viewType.FullName));
            }
            if (!typeof(IView).IsAssignableFrom(viewType))
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "To be used with shared presenters, the view type must inherit from {0}. The supplied type ({1}) does not.",
                    typeof(IView).FullName,
                    viewType.FullName));
            }
            if (!viewType.IsPublic && !viewType.IsNestedPublic)
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "To be used with shared presenters, the view type must be public. The supplied type ({0}) is not.",
                    viewType.FullName));
            }
        }

        static AssemblyName BuildAssemblyName()
        {
            var assemblyName = new AssemblyName("WebFormsMvp.CompositeViewTypes");
            return assemblyName;
        }

        static AssemblyBuilder BuildAssembly(AssemblyName assemblyName, AppDomain appDomain)
        {
            var attributeBuilders = new[]
            {
                new CustomAttributeBuilder(typeof(SecurityTransparentAttribute).GetConstructor(Type.EmptyTypes), new object[0])
            };

            var assembly = appDomain.DefineDynamicAssembly
            (
                assemblyName,
                AssemblyBuilderAccess.Run,
                attributeBuilders
            );
            
            return assembly;
        }

        static ModuleBuilder BuildModule(AssemblyBuilder assembly, AssemblyName assemblyName)
        {
            return assembly.DefineDynamicModule(assemblyName.Name);
        }

        static TypeBuilder BuildType(Type viewType, ModuleBuilder module)
        {
            var parentType = GetCompositeViewParentType(viewType);
            var interfaces = new[] { viewType };

            var type = module.DefineType(
                viewType.FullName + "__@CompositeView",
                TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.Class,
                parentType,
                interfaces);
            return type;
        }

        internal static Type GetCompositeViewParentType(Type viewType)
        {
            return typeof(CompositeView<>).MakeGenericType(viewType);
        }

        static IEnumerable<PropertyInfo> DiscoverProperties(Type type)
        {
            return type
                .GetProperties()
                .Union
                (
                    type.GetInterfaces()
                        .SelectMany<Type, PropertyInfo>(DiscoverProperties)
                )
                .Select(p => new
                {
                    PropertyInfo = p,
                    PropertyInfoFromCompositeViewBase = typeof(CompositeView<>).GetProperty(p.Name)
                })
                .Where(p =>
                    p.PropertyInfoFromCompositeViewBase == null ||
                    (p.PropertyInfoFromCompositeViewBase.GetGetMethod() == null && p.PropertyInfoFromCompositeViewBase.GetSetMethod() == null)
                )
                .Select(p => p.PropertyInfo);
        }

        static MethodBuilder BuildMethod(TypeBuilder type, string methodNamePrefix, string methodName, Type returnType, Type[] parameterTypes)
        {
            return type.DefineMethod(
                methodNamePrefix + "_" + methodName,
                MethodAttributes.Public |
                    MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig |
                    MethodAttributes.Virtual,
                returnType,
                parameterTypes);
        }

        static void EmitILForEachView(Type viewType, ILGenerator il, Action forEachAction)
        {
            // Declare the locals we need
            var viewLocal = il.DeclareLocal(viewType);
            var enumeratorLocal = il.DeclareLocal(typeof(IEnumerable<>).MakeGenericType(viewType));
            var enumeratorContinueLocal = il.DeclareLocal(typeof(bool));

            // Load the view instance on to the evaluation stack
            il.Emit(OpCodes.Ldarg, viewLocal.LocalIndex);

            // Call CompositeView<IViewType>.get_Views
            var getViews = typeof(CompositeView<>)
                .MakeGenericType(viewType)
                .GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic)
                .First(pi => pi.Name == "Views" &&
                    pi.PropertyType == typeof(IEnumerable<>).MakeGenericType(viewType))
                .GetGetMethod(true);
            il.EmitCall(OpCodes.Call, getViews, null);

            // Call IEnumerable<>.GetEnumerator
            var getViewsEnumerator = typeof(IEnumerable<>)
                .MakeGenericType(viewType)
                .GetMethod("GetEnumerator",
                    BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            il.EmitCall(OpCodes.Callvirt, getViewsEnumerator, null);

            // Push the enumerator from the evaluation stack to the local variable
            il.Emit(OpCodes.Stloc, enumeratorLocal.LocalIndex);

            // Start a new exception block so that we can reliably dispose
            // the enumerator
            il.BeginExceptionBlock();

            // Define some of the labels we need
            var moveNextLabel = il.DefineLabel();
            var continueLabel = il.DefineLabel();
            var endFinallyLabel = il.DefineLabel();
            var exitLabel = il.DefineLabel();

            // Skip straight ahead to moveNextLabel
            il.Emit(OpCodes.Br_S, moveNextLabel);

            // Mark this point with with continueLabel
            il.MarkLabel(continueLabel);

            // Push the enumerator on to the evaluation stack
            il.Emit(OpCodes.Ldloc, enumeratorLocal);

            // Call IEnumerator<>.get_Current on the enumerator
            var getCurrent =
                typeof(IEnumerator<>)
                .MakeGenericType(viewType)
                .GetProperty("Current")
                .GetGetMethod();
            il.EmitCall(OpCodes.Callvirt, getCurrent, null);

            // Store the output from IEnumerator<>.get_Current into a local
            il.Emit(OpCodes.Stloc, viewLocal);

            // Push the view local back onto the evaluation stack
            il.Emit(OpCodes.Ldloc, viewLocal);

            // Push the incoming set value onto the evaluation stack
            il.Emit(OpCodes.Ldarg, 1);

            // Let the calling method inject some IL here
            forEachAction();

            // Mark this point with the moveNextLabel
            il.MarkLabel(moveNextLabel);

            // Push the enumerator local back onto the evaluation stack
            il.Emit(OpCodes.Ldloc, enumeratorLocal);

            // Call IEnumerator.MoveNext on the enumerator
            var moveNext =
                typeof(IEnumerator)
                .GetMethod("MoveNext");
            il.EmitCall(OpCodes.Callvirt, moveNext, null);

            // Push the result of MoveNext from the evaluation stack to the local variable
            il.Emit(OpCodes.Stloc, enumeratorContinueLocal.LocalIndex);

            // Pull the result of MoveNext from the evaluation stack back onto the evaluation stack
            il.Emit(OpCodes.Ldloc, enumeratorContinueLocal.LocalIndex);

            // If MoveNext returned true, jump back to the continue label
            il.Emit(OpCodes.Brtrue_S, continueLabel);

            // Jump out of the try block
            il.Emit(OpCodes.Leave_S, exitLabel);

            // Start the finally block
            il.BeginFinallyBlock();

            // Push the enumerator onto the evaluation stack, then compare against null
            il.Emit(OpCodes.Ldloc, enumeratorLocal);
            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Ceq);

            // Pop the comparison result into our local
            il.Emit(OpCodes.Stloc, enumeratorContinueLocal);

            // If the comparison result was true, jump to the end of the finally block
            il.Emit(OpCodes.Ldloc, enumeratorContinueLocal);
            il.Emit(OpCodes.Brtrue_S, endFinallyLabel);

            // Push the enumerator onto the evaluation stack
            il.Emit(OpCodes.Ldloc, enumeratorLocal);

            // Call IDisposable.Dispose
            var dispose =
                typeof(IDisposable)
                .GetMethod("Dispose");
            il.Emit(OpCodes.Callvirt, dispose);

            // Mark this point as exit point for our finally block
            il.MarkLabel(endFinallyLabel);

            // Close the try block
            il.EndExceptionBlock();

            // Mark this point as our exit point (used to get out of the try block)
            il.MarkLabel(exitLabel);
        }

        static void BuildProperties(TypeBuilder type, Type viewType, IEnumerable<PropertyInfo> properties)
        {
            foreach (var propertyInfo in properties)
            {
                BuildProperty(type, viewType, propertyInfo);
            }
        }

        static void BuildProperty(TypeBuilder type, Type viewType, PropertyInfo propertyInfo)
        {
            MethodBuilder getMethod =  null;
            if (propertyInfo.CanRead)
            {
                getMethod = BuildPropertyGetMethod(type, viewType, propertyInfo);
            }

            MethodBuilder setMethod = null;
            if (propertyInfo.CanWrite)
            {
                setMethod = BuildPropertySetMethod(type, viewType, propertyInfo);
            }

            var property = type.DefineProperty(
                propertyInfo.Name,
                propertyInfo.Attributes,
                propertyInfo.PropertyType,
                Type.EmptyTypes);

            if (getMethod != null)
            {
                property.SetGetMethod(getMethod);
            }
            if (setMethod != null)
            {
                property.SetSetMethod(setMethod);
            }
        }

        static MethodBuilder BuildPropertyGetMethod(TypeBuilder type, Type viewType, PropertyInfo propertyInfo)
        {
            /*
             * Produces something functionally equivalent to this:
             * 

get
{
    return Views.First().Model;
}

             * 
             * It does this by emitting IL like this:
             * 

.method public hidebysig newslot specialname virtual final 
    instance class WebFormsMvp.FeatureDemos.Logic.Views.Models.CompositeDemoViewModel 
    get_Model() cil managed
{
    // Code size       22 (0x16)
    .maxstack  1
    .locals init ([0] class WebFormsMvp.FeatureDemos.Logic.Views.Models.CompositeDemoViewModel CS$1$0000)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  call       instance class [mscorlib]System.Collections.Generic.IEnumerable`1<!0> class [WebFormsMvp]WebFormsMvp.CompositeView`1<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView>::get_Views()
    IL_0007:  call       !!0 [System.Core]System.Linq.Enumerable::First<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_000c:  callvirt   instance !0 class [WebFormsMvp]WebFormsMvp.IView`1<class WebFormsMvp.FeatureDemos.Logic.Views.Models.CompositeDemoViewModel>::get_Model()
    IL_0011:  stloc.0
    IL_0012:  br.s       IL_0014
    IL_0014:  ldloc.0
    IL_0015:  ret
} // end of method CompositeDemoViewComposite::get_Model

             * 
             */

            var getBuilder = BuildMethod(
                type,
                "get",
                propertyInfo.Name,
                propertyInfo.PropertyType,
                Type.EmptyTypes);

            var il = getBuilder.GetILGenerator();

            // Declare a local to store the return value in
            var local = il.DeclareLocal(propertyInfo.PropertyType);

            // Load the view instance on to the evaluation stack
            il.Emit(OpCodes.Ldarg, local.LocalIndex);

            // Call CompositeView<IViewType>.get_Views
            var getViews = typeof(CompositeView<>)
                .MakeGenericType(viewType)
                .GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic)
                .First(pi => pi.Name == "Views" &&
                    pi.PropertyType == typeof(IEnumerable<>).MakeGenericType(viewType))
                .GetGetMethod(true);
            il.EmitCall(OpCodes.Call, getViews, null);

            // Call IEnumerable.First<IViewType>
            var firstView = typeof(Enumerable)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(mi => mi.Name == "First")
                .Single(mi =>
                {
                    var parameters = mi.GetParameters();
                    return parameters.Length == 1 &&
                        parameters[0].ParameterType.GUID == typeof(IEnumerable<>).GUID;
                })
                .MakeGenericMethod(viewType);
            il.EmitCall(OpCodes.Call, firstView, null);

            // Call the original getter, eg. IViewType.get_SomeProperty
            var originalGetter = propertyInfo.GetGetMethod();
            il.EmitCall(OpCodes.Callvirt, originalGetter, null);

            // Push it from the evaluation stack to the local variable
            il.Emit(OpCodes.Stloc, local.LocalIndex);

            // Push it from the local variable back onto the evaluation stack
            il.Emit(OpCodes.Ldloc, local.LocalIndex);

            // Return control
            il.Emit(OpCodes.Ret);

            return getBuilder;
        }

        static MethodBuilder BuildPropertySetMethod(TypeBuilder type, Type viewType, PropertyInfo propertyInfo)
        {
            /*
             * Produces something functionally equivalent to this:
             * 

set
{
    foreach(var view in Views)
        view.Model = value;
}

             * 
             * It does this by emitting IL like this:
             * 

.method public hidebysig newslot specialname virtual final 
    instance void  set_Model(class WebFormsMvp.FeatureDemos.Logic.Views.Models.CompositeDemoViewModel 'value') cil managed
{
    // Code size       61 (0x3d)
    .maxstack  2
    .locals init ([0] class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView view,
        [1] class [mscorlib]System.Collections.Generic.IEnumerator`1<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView> CS$5$0000,
        [2] bool CS$4$0001)
    IL_0000:  nop
    IL_0001:  nop
    IL_0002:  ldarg.0
    IL_0003:  call       instance class [mscorlib]System.Collections.Generic.IEnumerable`1<!0> class [WebFormsMvp]WebFormsMvp.CompositeView`1<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView>::get_Views()
    IL_0008:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView>::GetEnumerator()
    IL_000d:  stloc.1
    .try
    {
        IL_000e:  br.s       IL_001f

        IL_0010:  ldloc.1
        IL_0011:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class WebFormsMvp.FeatureDemos.Logic.Views.ICompositeDemoView>::get_Current()
        IL_0016:  stloc.0
        IL_0017:  ldloc.0
        IL_0018:  ldarg.1
        IL_0019:  callvirt   instance void class [WebFormsMvp]WebFormsMvp.IView`1<class WebFormsMvp.FeatureDemos.Logic.Views.Models.CompositeDemoViewModel>::set_Model(!0)
        IL_001e:  nop
        IL_001f:  ldloc.1
        IL_0020:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_0025:  stloc.2
        IL_0026:  ldloc.2
        IL_0027:  brtrue.s   IL_0010

        IL_0029:  leave.s    IL_003b

    }  // end .try
    finally
    {
        IL_002b:  ldloc.1
        IL_002c:  ldnull
        IL_002d:  ceq
        IL_002f:  stloc.2
        IL_0030:  ldloc.2
        IL_0031:  brtrue.s   IL_003a

        IL_0033:  ldloc.1
        IL_0034:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0039:  nop
        IL_003a:  endfinally
    }  // end handler
    IL_003b:  nop
    IL_003c:  ret
} // end of method CompositeDemoViewComposite::set_Model

             */

            var setBuilder = BuildMethod(
                type,
                "set",
                propertyInfo.Name,
                typeof(void),
                new [] { propertyInfo.PropertyType });

            var il = setBuilder.GetILGenerator();

            EmitILForEachView(viewType, il,
                () =>
                {
                    // Call the original setter
                    var originalSetter = propertyInfo.GetSetMethod();
                    il.EmitCall(OpCodes.Callvirt, originalSetter, null);
                });

            // Return control
            il.Emit(OpCodes.Ret);

            return setBuilder;
        }

        static IEnumerable<EventInfo> DiscoverEvents(Type type)
        {
            return type
                .GetEvents()
                .Union
                (
                    type.GetInterfaces()
                        .SelectMany<Type, EventInfo>(DiscoverEvents)
                );
        }

        static void BuildEvents(TypeBuilder type, Type viewType, IEnumerable<EventInfo> events)
        {
            foreach (var eventInfo in events)
            {
                BuildEvent(type, viewType, eventInfo);
            }
        }

        static void BuildEvent(TypeBuilder type, Type viewType, EventInfo eventInfo)
        {
            var addMethod = BuildEventAddMethod(type, viewType, eventInfo);
            var removeMethod = BuildEventRemoveMethod(type, viewType, eventInfo);
            
            if (eventInfo.EventHandlerType == null)
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "The supplied event {0} from {1} does not have the event handler type specified.",
                    eventInfo.Name,
                    eventInfo.ReflectedType.Name),
                    "eventInfo");
            }

            var @event = type.DefineEvent(
                eventInfo.Name,
                eventInfo.Attributes,
                eventInfo.EventHandlerType);

            @event.SetAddOnMethod(addMethod);
            @event.SetRemoveOnMethod(removeMethod);
        }

        static MethodBuilder BuildEventAddMethod(TypeBuilder type, Type viewType, EventInfo eventInfo)
        {
            var addBuilder = BuildMethod(
                type,
                "add",
                eventInfo.Name,
                typeof(void),
                new [] { eventInfo.EventHandlerType });
            
            var il = addBuilder.GetILGenerator();

            EmitILForEachView(viewType, il,
                () =>
                {
                    // Call the original add method
                    var originalAddMethod = eventInfo.GetAddMethod();
                    il.EmitCall(OpCodes.Callvirt, originalAddMethod, null);
                });

            // Return control
            il.Emit(OpCodes.Ret);

            return addBuilder;
        }

        static MethodBuilder BuildEventRemoveMethod(TypeBuilder type, Type viewType, EventInfo eventInfo)
        {
            var removeBuilder =  BuildMethod(
                type,
                "remove",
                eventInfo.Name,
                typeof(void),
                new [] { eventInfo.EventHandlerType });

            var il = removeBuilder.GetILGenerator();

            EmitILForEachView(viewType, il,
                () =>
                {
                    // Call the original remove method
                    var originalRemoveMethod = eventInfo.GetRemoveMethod();
                    il.EmitCall(OpCodes.Callvirt, originalRemoveMethod, null);
                });

            // Return control
            il.Emit(OpCodes.Ret);

            return removeBuilder;
        }
    }
}