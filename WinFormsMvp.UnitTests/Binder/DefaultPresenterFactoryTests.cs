using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;
using WinFormsMvp.UnitTests.Presenters;
using WinFormsMvp.UnitTests.Views;

namespace WinFormsMvp.UnitTests.Binder
{
    /// <summary>
    /// Summary description for DefaultPresenterFactoryTests
    /// </summary>
    [TestClass]
    public class DefaultPresenterFactoryTests
    {
        [TestMethod]
        public void CreatePresenterTest()
        {
            //  Arrange
            DefaultPresenterFactory defaultPresenterFactory = new DefaultPresenterFactory();
            CreateProjectForm view = new CreateProjectForm();
            CreateProjectPresenter createProjectPresenter = new CreateProjectPresenter(view);

            //  Act
            var actualPresenter = defaultPresenterFactory.Create(typeof(CreateProjectPresenter), typeof(CreateProjectForm), view);

            //  Assert
            Assert.IsInstanceOfType(actualPresenter, typeof(CreateProjectPresenter));
        }

        [TestMethod]
        public void CreatePresenterWithNonGenericView()
        {
            //  Arrange
            DefaultPresenterFactory defaultPresenterFactory = new DefaultPresenterFactory();
            LaunchView view = new LaunchView();
            //LaunchPresenter createProjectPresenter = new LaunchPresenter(view);

            //  Act
            var actualPresenter = defaultPresenterFactory.Create(typeof(LaunchPresenter), typeof(LaunchView), view);

            //  Assert
            Assert.IsInstanceOfType(actualPresenter, typeof(LaunchPresenter));
        }
    }
}
