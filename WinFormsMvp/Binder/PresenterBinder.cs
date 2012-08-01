using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WinFormsMvp.Binder
{
    /// <summary/>
    public sealed class PresenterBinder
    {
        static IPresenterFactory factory;
        ///<summary>
        /// Gets or sets the factory that the binder will use to create
        /// new presenter instances. This is pre-initialized to a
        /// default implementation but can be overriden if desired.
        /// This property can only be set once.
        ///</summary>
        ///<exception cref="ArgumentNullException">Thrown if a null value is passed to the setter.</exception>
        ///<exception cref="InvalidOperationException">Thrown if the property is being set for a second time.</exception>
        public static IPresenterFactory Factory
        {
            get
            {
                return factory ?? (factory = new DefaultPresenterFactory());
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (factory != null)
                {
                    throw new InvalidOperationException(
                        factory is DefaultPresenterFactory
                        ? "The factory has already been set, and can be not changed at a later time. In this case, it has been set to the default implementation. This happens if the factory is used before being explicitly set. If you wanted to supply your own factory, you need to do this in your Application_Start event."
                        : "You can only set your factory once, and should really do this in Application_Start.");
                }
                factory = value;
            }
        }

        static IPresenterDiscoveryStrategy discoveryStrategy;
        ///<summary>
        /// Gets or sets the strategy that the binder will use to discover which presenters should be bound to which views.
        /// This is pre-initialized to a default implementation but can be overriden if desired. To combine multiple
        /// strategies in a fallthrough approach, use <see cref="CompositePresenterDiscoveryStrategy"/>.
        ///</summary>
        ///<exception cref="ArgumentNullException">Thrown if a null value is passed to the setter.</exception>
        public static IPresenterDiscoveryStrategy DiscoveryStrategy
        {
            get
            {
                //return discoveryStrategy ?? (discoveryStrategy = new AttributeBasedPresenterDiscoveryStrategy());
                return discoveryStrategy ?? (discoveryStrategy = new CompositePresenterDiscoveryStrategy(
                    new AttributeBasedPresenterDiscoveryStrategy(),
                    new ConventionBasedPresenterDiscoveryStrategy()
                    ));
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                discoveryStrategy = value;
            }
        }

        static readonly ICompositeViewTypeFactory compositeViewTypeFactory = new DefaultCompositeViewTypeFactory();

        readonly IList<IPresenter> presenters = new List<IPresenter>();

        /// <summary>
        /// Occurs when the binder creates a new presenter instance. Useful for
        /// populating extra information into presenters.
        /// </summary>
        public event EventHandler<PresenterCreatedEventArgs> PresenterCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterBinder"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="httpContext">The owning HTTP context.</param>
        public PresenterBinder()
        {
            
        }



        ///// <summary>
        ///// Initializes a new instance of the <see cref="PresenterBinder"/> class.
        ///// </summary>
        ///// <param name="hosts">The array of hosts, useful in scenarios like ASP.NET master pages.</param>
        ///// <param name="httpContext">The owning HTTP context.</param>
        ///// <param name="traceContext">The tracing context.</param>
        //internal PresenterBinder(IEnumerable<object> hosts)
        //{
        //    this.hosts = hosts.ToList();

        //    foreach (var selfHostedView in hosts.OfType<IView>())
        //    {
                
        //    }
        //}

        /// <summary>
        /// Registers a view instance as being a candidate for binding. If
        /// <see cref="PerformBinding()"/> has not been called, the view will
        /// be queued until that time. If <see cref="PerformBinding()"/> has
        /// already been called, binding is attempted instantly.
        /// </summary>
        //public void RegisterView(IView viewInstance)
        //{
        //    PerformBinding(viewInstance);
        //}

        /// <summary>
        /// Attempts to bind any already registered views.
        /// </summary>
        public void PerformBinding(IView viewInstance)
        {
            try
            {
                var newPresenters = PerformBinding(
                    viewInstance,
                    DiscoveryStrategy,
                    p => OnPresenterCreated(new PresenterCreatedEventArgs(p)),
                    Factory);

                //presenters.AddRange(newPresenters);
                //presenters.Clear();
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Closes the message bus, releases each of the views from the
        /// presenters then releases each of the presenters from the factory
        /// (useful in IoC scenarios).
        /// </summary>
        public void Release()
        {
            //traceContext.Write(this, () => "Releasing presenter binder.");

            //MessageCoordinator.Close();
            //lock (presenters)
            //{
            //    foreach (var presenter in presenters)
            //    {
            //        var presenter1 = presenter;

            //        traceContext.Write(this, () => string.Format(
            //            CultureInfo.InvariantCulture,
            //            "Calling ReleaseView on presenter of type {0}.",
            //            presenter1.GetType().FullName));

            //        var presenterThatWeNeedToCallReleaseViewOn = presenter as IViewLifecycleManager;
            //        if (presenterThatWeNeedToCallReleaseViewOn != null)
            //        {
            //            presenterThatWeNeedToCallReleaseViewOn.ReleaseView();
            //        }

            //        traceContext.Write(this, () => string.Format(
            //            CultureInfo.InvariantCulture,
            //            "Releasing presenter of type {0} back to the presenter factory.",
            //            presenter1.GetType().FullName));

            //        factory.Release(presenter);
            //    }
            //    presenters.Clear();
            //}
        }

        private void OnPresenterCreated(PresenterCreatedEventArgs args)
        {
            if (PresenterCreated != null)
            {
                PresenterCreated(this, args);
            }
        }

        static IPresenter PerformBinding(
            IView candidate,
            IPresenterDiscoveryStrategy presenterDiscoveryStrategy,
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory)
        {
            var bindings = GetBindings(
                candidate,
                presenterDiscoveryStrategy);

            var newPresenters = BuildPresenters(
                presenterCreatedCallback,
                presenterFactory,
                new PresenterBinding[] {bindings});

            return newPresenters;
        }

        static PresenterBinding GetBindings(
            IView candidate,
            IPresenterDiscoveryStrategy presenterDiscoveryStrategy)
        {
            //ThrowExceptionsForViewsWithNoPresenterBound(results);

            return  presenterDiscoveryStrategy.GetBinding(candidate).Bindings.ElementAt(0);
        }

        static void ThrowExceptionsForViewsWithNoPresenterBound(IEnumerable<PresenterDiscoveryResult> results)
        {
            var resultToThrowExceptionsFor = results
                .Where(r => r.Bindings.Empty())
                .Where(r => r
                    .ViewInstances
                    .Where(v => v.ThrowExceptionIfNoPresenterBound)
                    .Any())
                .FirstOrDefault();

            if (resultToThrowExceptionsFor == null) return;

            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                @"Failed to find presenter for view instance of {0}.{1} If you do not want this exception to be thrown, set ThrowExceptionIfNoPresenterBound to false on your view.",
                resultToThrowExceptionsFor
                    .ViewInstances
                    .Where(v => v.ThrowExceptionIfNoPresenterBound)
                    .First()
                    .GetType()
                    .FullName,
                resultToThrowExceptionsFor.Message
            ));
        }

        static IEnumerable<string> BuildTraceMessagesForBindings(IPresenterDiscoveryStrategy presenterDiscoveryStrategy, IEnumerable<PresenterDiscoveryResult> results)
        {
            var strategyName = presenterDiscoveryStrategy.GetType().FullName;
            return results
                .Where(r => r.Bindings.Any())
                .Select(result => string.Format(
                    CultureInfo.InvariantCulture,
                    @"Found {0} presenter {1} for {2} using {3}.{4}{5}",
                    result.Bindings.Count(),
                    result.Bindings.Count() == 1 ? "binding" : "bindings",
                    string.Join(", ", result.ViewInstances.Select(v => v.GetType().FullName).ToArray()),
                    strategyName,
                    result.Message,
                    string.Join("\r\n\r\n",
                        result
                            .Bindings
                            .Select(b => string.Format(
                                CultureInfo.InvariantCulture,
                                @"Presenter type: {0}    View type: {1}    Binding mode: {2}",
                                b.PresenterType.FullName,
                                b.ViewType.FullName,
                                b.BindingMode
                            ))
                            .ToArray()
                    )
                ));
        }

        static IPresenter BuildPresenters(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            IEnumerable<PresenterBinding> bindings)
        {
            return bindings
                .Select(binding =>
                    BuildPresenters(
                        presenterCreatedCallback,
                        presenterFactory,
                        binding)).ToList().ElementAt(0);
        }

        static IPresenter BuildPresenters(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            PresenterBinding binding)
        {
            IView viewToCreateFor = null;

            switch (binding.BindingMode)
            {
                case BindingMode.Default:
                    viewToCreateFor = binding.ViewInstance;
                    break;
                //case BindingMode.SharedPresenter:
                //    //viewToCreateFor = new[]
                //    //{
                //    //    CreateCompositeView(binding.ViewType, binding.ViewInstance)
                //    //};
                //    break;
                default:
                    throw new NotSupportedException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Binding mode {0} is not supported by this method.",
                        binding.BindingMode));
            }

            return BuildPresenter(
                    presenterCreatedCallback,
                    presenterFactory,
                    binding,
                    viewToCreateFor);
        }

        static IPresenter BuildPresenter(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            PresenterBinding binding,
            IView viewInstance)
        {

            var presenter = presenterFactory.Create(binding.PresenterType, binding.ViewType, viewInstance);
            if (presenterCreatedCallback != null)
            {
                presenterCreatedCallback(presenter);
            }
            return presenter;
        }

        //internal static IView CreateCompositeView(Type viewType, IEnumerable<IView> childViews)
        //{
        //    var compositeViewType = compositeViewTypeFactory.BuildCompositeViewType(viewType);
        //    var view = (ICompositeView)Activator.CreateInstance(compositeViewType);
        //    foreach (var v in childViews)
        //    {
        //        view.Add(v);
        //    }
        //    return view;
        //}
    }
}