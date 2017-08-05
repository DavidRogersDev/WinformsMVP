using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;
using WinFormsMvp.UnitTests.Models;
using WinFormsMvp.UnitTests.Views;
using WinFormsMvp.UnitTests.Presenters;

namespace WinFormsMvp.UnitTests.Binder
{
    /// <summary>
    /// Summary description for CompositePresenterDiscoveryStrategyTests
    /// </summary>
    [TestClass]
    public class ConventionBasedPresenterDiscoveryStrategyTests
    {
        [TestMethod]
        public void GetBinding_When_Valid_View_Passed_In()
        {
            //  Arrange
            var strategy = new ConventionBasedPresenterDiscoveryStrategy();
            IView<CreateProjectModel> mainView = new CreateProjectForm();

            //  Act
            var actualBinding = strategy.GetBinding(mainView);

            //  Assert
            Assert.IsTrue(actualBinding.Bindings.Any());
            Assert.IsTrue(actualBinding.Bindings.First().PresenterType == typeof(CreateProjectPresenter));

        }

        [TestMethod]
        public  void Get_Binding_When_Both_Binding_Mechansims_Used()
        {
            //  Arrange
            var strategy = new ConventionBasedPresenterDiscoveryStrategy();
            IView<CreateTaskModel> createTaskView = new CreateTaskView();

            //Act
            var actualBinding = strategy.GetBinding(createTaskView);

            //  Assert
            Assert.IsTrue(actualBinding.Bindings.Any());
            Assert.IsTrue(actualBinding.Bindings.First().PresenterType == typeof(CreateTaskPresenter));
        }
    }
}
