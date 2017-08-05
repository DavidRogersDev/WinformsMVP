using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;
using WinFormsMvp.UnitTests.Views;
using WinFormsMvp.UnitTests.Models;
using WinFormsMvp.UnitTests.Presenters;

namespace WinFormsMvp.UnitTests.Binder
{
    /// <summary>
    /// Summary description for AttributeBasedPresenterDiscoveryStrategy_Tests
    /// </summary>
    [TestClass]
    public class AttributeBasedPresenterDiscoveryStrategyTests
    {
        public AttributeBasedPresenterDiscoveryStrategyTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetBinding_When_Valid_View_Passed_In()
        {
            //  Arrange
            var strategy = new AttributeBasedPresenterDiscoveryStrategy();
            IView<MainFormModel> mainView = new MainView();

            //  Act
            var actualBinding = strategy.GetBinding(mainView);

            //  Assert
            Assert.IsTrue(actualBinding.Bindings.Any());
            Assert.IsTrue(actualBinding.Bindings.First().PresenterType == typeof(MainEntryMenuPresenter));
        }

        [TestMethod]
        public void Get_Binding_When_Both_Binding_Mechansims_Used()
        {
            //  Arrange
            var strategy = new AttributeBasedPresenterDiscoveryStrategy();
            IView<CreateTaskModel> createTaskView = new CreateTaskView();

            //Act
            var actualBinding = strategy.GetBinding(createTaskView);

            //  Assert
            Assert.IsTrue(actualBinding.Bindings.Any());
            Assert.IsTrue(actualBinding.Bindings.First().PresenterType == typeof(CreateTaskPresenter));
        }
    }
}
