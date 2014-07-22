using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WinFormsMvp.Binder;
using WinFormsMvp.UnitTests.Presenters;
using WinFormsMvp.UnitTests.Views;

namespace WinFormsMvp.UnitTests
{
    [TestClass]
    public class AppStateTests
    {
        //private IPresenter _mainPresenter;
        //private IPresenter _launchPresenter;
        //private const string KeyForAppState = "NewItem";
        //private const string NotPresentInState = "NotPresentInState";
        //private IEnumerable<string> _someStrings;

        //[TestInitialize]
        //public void Setup()
        //{
        //    var mainView = new MainView();
        //    var launchView = new LaunchView();

        //    _someStrings = new[] {"Quick", "Brown", "Fox"};

        //    var presenterBinder = new PresenterBinder();
        //    presenterBinder.PresenterCreated += PresenterBinderPresenterCreated;
        //    presenterBinder.PerformBinding(mainView);
        //    presenterBinder.PerformBinding(launchView);

        //}

        //[TestCleanup]
        //public void TearDown()
        //{
        //    _mainPresenter.Items.Clear();
        //    _launchPresenter.Items.Clear();
        //}

        //[TestMethod]
        //public void AddItemAddsAnItemToAppState()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(KeyForAppState, _someStrings);

        //    //  Assert 
        //    Assert.IsTrue(_launchPresenter.Items.HasItem(KeyForAppState));
        //}

        //[TestMethod]
        //public void GetItemRetrievesItemFromAppState()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(KeyForAppState, _someStrings);

        //    var strings = _launchPresenter.Items.GetItem<IEnumerable<string>>(KeyForAppState);

        //    //  Assert 
        //    Assert.IsTrue(strings.SequenceEqual(_someStrings));
            
        //}

        //[TestMethod]
        //public void RemoveItemRemovesItemFromAppState()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(KeyForAppState, _someStrings);

        //    _launchPresenter.Items.RemoveItem<IEnumerable<string>>(KeyForAppState);

        //    //  Assert 
        //    Assert.IsFalse(_mainPresenter.Items.HasItem(KeyForAppState));
            
        //}


        //[TestMethod]
        //public void ClearRemovesAllItemsFromAppState()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(KeyForAppState, _someStrings);

        //    _launchPresenter.Items.Clear();

        //    //  Assert 
        //    Assert.IsFalse(_mainPresenter.Items.HasItem(KeyForAppState));

        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "The key cannot be either null, or an empty string.")]
        //public void EmptyKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(string.Empty, _someStrings);

        //    //  Assert 
        //    Assert.Fail();

        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "The key cannot be either null, or an empty string.")]
        //public void NullKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.AddItem(null, _someStrings);

        //    //  Assert 
        //    Assert.Fail();

        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "The key cannot be either null, or an empty string.")]
        //public void RetrieveWithNullKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.GetItem<IEnumerable<string>>(null);

        //    //  Assert 
        //    Assert.Fail();

        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "The key cannot be either null, or an empty string.")]
        //public void RetrieveWithEmptyKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.GetItem<IEnumerable<string>>(string.Empty);

        //    //  Assert 
        //    Assert.Fail();

        //}

        //[TestMethod]
        //public void CheckWithEmptyKeyReturnsFalse()
        //{
        //    //  Arrange
        //    //  Act
        //    var itemPresent = _mainPresenter.Items.HasItem(string.Empty);

        //    //  Assert 
        //    Assert.IsFalse(itemPresent);

        //}


        //[TestMethod]
        //public void CheckWithWrongKeyReturnsFalse()
        //{
        //    //  Arrange
        //    //  Act
        //    var itemPresent = _mainPresenter.Items.HasItem(NotPresentInState);

        //    //  Assert 
        //    Assert.IsFalse(itemPresent);

        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "Value cannot be null.")]
        //public void CheckWithNullKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    var itemPresent = _mainPresenter.Items.HasItem(null);

        //    //  Assert 
        //    Assert.Fail();

        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "Value cannot be null.")]
        //public void RemoveNullKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.RemoveItem<IEnumerable<string>>(null);

        //    //  Assert 
        //    Assert.Fail();
        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "The key cannot be either null, or an empty string.")]
        //public void RemoveEmptyKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.RemoveItem<IEnumerable<string>>(string.Empty);

        //    //  Assert 
        //    Assert.Fail();
        //}

        //[TestMethod]
        //[ExpectedException(typeof(KeyNotFoundException))]
        //public void RemoveNonexistantKeyThrowsException()
        //{
        //    //  Arrange
        //    //  Act
        //    _mainPresenter.Items.RemoveItem<IEnumerable<string>>(NotPresentInState);

        //    //  Assert 
        //    Assert.Fail();
        //}

        //void PresenterBinderPresenterCreated(object sender, PresenterCreatedEventArgs e)
        //{
        //    if(e.Presenter.GetType() == typeof(MainEntryMenuPresenter))
        //        _mainPresenter = e.Presenter;

        //    if(e.Presenter.GetType() == typeof(LaunchPresenter))
        //        _launchPresenter = e.Presenter;
        //}


    }
}
