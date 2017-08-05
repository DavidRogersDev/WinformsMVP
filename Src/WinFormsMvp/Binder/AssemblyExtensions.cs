using System;
using System.Reflection;

namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Extension methods for Assembly class
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns the short name of an assembly in a way that is safe in medium trust
        /// </summary>
        /// <param name="assembly">The assembly to return the name for</param>
        /// <returns>The assembly short name</returns>
        public static string GetNameSafe(this Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            return new AssemblyName(assembly.FullName).Name;
        }
    }
}
