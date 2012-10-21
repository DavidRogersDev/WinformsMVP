using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WinFormsMvp;

namespace WinFormsMvp.UnitTests
{
    /// <summary>
    ///This is an exact copy of the TypeExtensionsTests from the original WebFormsMVP project (thanks guys!)
    /// </summary>
    [TestClass]
    public class TypeExtensionsTests
    {
        [TestMethod]
        public void TypeExtensions_GetViewInterfaces_ShouldReturnForIView()
        {
            // Arrange
            var instanceType = MockRepository
                .GenerateMock<IView>()
                .GetType();

            // Act
            var actual = instanceType.GetViewInterfaces();

            // Assert
            var expected = new[] { typeof(IView) };
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void TypeExtensions_GetViewInterfaces_ShouldReturnForIViewT()
        {
            // Arrange
            var instanceType = MockRepository
                .GenerateMock<IView<object>>()
                .GetType();

            // Act
            var actual = instanceType.GetViewInterfaces();

            // Assert
            var expected = new[] { typeof(IView), typeof(IView<object>) };
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        public interface GetViewInterfaces_CustomIView : IView { }
        [TestMethod]
        public void TypeExtensions_GetViewInterfaces_ShouldReturnForCustomIView()
        {
            // Arrange
            var instanceType = MockRepository
                .GenerateMock<GetViewInterfaces_CustomIView>()
                .GetType();

            // Act
            var actual = instanceType.GetViewInterfaces();

            // Assert
            var expected = new[] { typeof(IView), typeof(GetViewInterfaces_CustomIView) };
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        public interface GetViewInterfaces_CustomIViewT : IView<object> { }
        [TestMethod]
        public void TypeExtensions_GetViewInterfaces_ShouldReturnForCustomIViewT()
        {
            // Arrange
            var instanceType = MockRepository
                .GenerateMock<GetViewInterfaces_CustomIViewT>()
                .GetType();

            // Act
            var actual = instanceType.GetViewInterfaces();

            // Assert
            var expected = new[] {
                typeof(IView),
                typeof(IView<object>),
                typeof(GetViewInterfaces_CustomIViewT) };
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        public interface GetViewInterfaces_ChainedCustomIView : GetViewInterfaces_CustomIView { }
        [TestMethod]
        public void TypeExtensions_GetViewInterfaces_ShouldReturnForChainedCustomIView()
        {
            // Arrange
            var instanceType = MockRepository
                .GenerateMock<GetViewInterfaces_ChainedCustomIView>()
                .GetType();

            // Act
            var actual = instanceType.GetViewInterfaces();

            // Assert
            var expected = new[] {
                typeof(IView),
                typeof(GetViewInterfaces_CustomIView),
                typeof(GetViewInterfaces_ChainedCustomIView)};
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }
    }
}

