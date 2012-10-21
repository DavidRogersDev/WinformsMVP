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
    ///This is an exact copy of the CompositeViewTests from the original WebFormsMVP project (thanks guys!)
    /// </summary>
    [TestClass]
    public class CompositeViewTests
    {
        public class MyView : CompositeView<IView<object>>
        {
            public override event EventHandler Load;
        }

        [TestMethod]
        public void CompositeView_Add_ShouldAddToList()
        {
            // Arrange
            var compositeView = new MyView();
            var view1 = MockRepository.GenerateMock<IView<object>>();
            var view2 = MockRepository.GenerateMock<IView<object>>();

            // Act
            compositeView.Add(view1);
            compositeView.Add(view2);

            // Assert
            var expected = new[] { view1, view2 };
            Assert.IsTrue(expected.SequenceEqual(compositeView.Views));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompositeView_Add_ShouldThrowArgumentNullExceptionIfViewIsNull()
        {
            // Arrange
            var compositeView = new MyView();

            // Act
            compositeView.Add(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompositeView_Add_ShouldThrowArgumentExceptionIfViewTypeIsWrong()
        {
            // Arrange
            var compositeView = new MyView();

            // Act
            compositeView.Add(MockRepository.GenerateMock<IView>());

            // Assert
        }
    }
}
