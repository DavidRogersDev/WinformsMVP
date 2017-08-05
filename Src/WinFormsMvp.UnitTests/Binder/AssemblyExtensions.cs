using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;

namespace WinFormsMvp.UnitTests.Binder
{
    [TestClass]
    public class AssemblyExtensions
    {
        // ReSharper disable InconsistentNaming

        [TestMethod]
        public void AssemblyExtensions_GetNameSafe_GetsCorrectName()
        {
            var assembly = GetType().Assembly;

            var result = assembly.GetNameSafe();

            Assert.AreEqual(assembly.GetName().Name, result);
        }
    }
}
