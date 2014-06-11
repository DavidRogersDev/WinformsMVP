using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace WinFormsMvp.UnitTests
{
    /// <summary>
    /// This is a copy of the relevant PresenterTests from the original WebFormsMVP project (thanks guys!)
    /// </summary>
    [TestClass]
    public class PresenterTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Presenter_Constructor_ShouldIntializeDefaultViewModelForViewTypesThatImplementIViewTModel()
        {
            // Arrange
            var view = new TestViewWithModel();

            // Act
            new TestPresenterWithModelBasedView(view);

            // Assert
            Assert.IsNotNull(view.Model);
        }

        [TestMethod]
        public void Presenter_Constructor_ShouldSupportNonModelBasedViews()
        {
            // Arrange
            var view = MockRepository.GenerateMock<IView>();

            // Act
            new TestPresenter(view);

            // Assert
        }

        class TestModel { }

        class TestViewWithModel : IView<TestModel>
        {
            event EventHandler IView.Load
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }

            public TestModel Model { get; set; }
            public bool ThrowExceptionIfNoPresenterBound
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        class TestPresenterWithModelBasedView
            : Presenter<TestViewWithModel>
        {
            public TestPresenterWithModelBasedView(TestViewWithModel view)
                : base(view)
            {
                View.Model = new TestModel();
            }
        }

        class TestPresenter : Presenter<IView>
        {
            public TestPresenter(IView view) : base(view) { }
        }
    }

}
