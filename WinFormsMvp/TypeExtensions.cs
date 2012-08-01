using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsMvp
{
    internal static class TypeExtensions
    {
        static readonly IDictionary<RuntimeTypeHandle, IEnumerable<Type>> implementationTypeToViewInterfacesCache = new Dictionary<RuntimeTypeHandle, IEnumerable<Type>>();
        internal static IEnumerable<Type> GetViewInterfaces(this Type implementationType)
        {
            // We use the type handle as the cache key because they're fast
            // to search against in dictionaries.
            var implementationTypeHandle = implementationType.TypeHandle;

            return implementationTypeToViewInterfacesCache.GetOrCreateValue(implementationTypeHandle, () =>
                implementationType
                    .GetInterfaces()
                    .Where(typeof(IView).IsAssignableFrom)
                    .ToArray()
            );
        }
    }
}
