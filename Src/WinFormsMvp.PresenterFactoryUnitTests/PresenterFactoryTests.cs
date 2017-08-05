using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;

namespace WinFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public abstract class PresenterFactoryTests
    {
        protected abstract IPresenterFactory BuildFactory();

        [TestMethod]
        public void Create_ShouldReturnInstance()
        {
            var factory = BuildFactory();
            var viewInstance = new View1();

            var presenter = factory.Create(typeof(BasicPresenter), typeof(IView), viewInstance);

            Assert.IsInstanceOfType(presenter, typeof(BasicPresenter));
        }

        [TestMethod]
        public virtual void Create_ShouldReturnDistinctInstanceForEachCall()
        {
            var factory = BuildFactory();
            var viewInstance = new View1();

            var presenter1 = factory.Create(typeof(BasicPresenter), typeof(IView), viewInstance);
            var presenter2 = factory.Create(typeof(BasicPresenter), typeof(IView), viewInstance);

            Assert.IsFalse(ReferenceEquals(presenter1, presenter2));
        }

        [TestMethod]
        public void Create_ShouldReturnInstanceWhenViewInstanceIsASuperTypeOfThePresenterSignature()
        {
            var factory = BuildFactory();
            var viewInstance = new View1();

            var presenter = factory.Create(typeof(BasicPresenter), typeof(View1), viewInstance);

            Assert.IsInstanceOfType(presenter, typeof(BasicPresenter));
        }

        [TestMethod]
        public void Release_ShouldCallDisposeIfThePresenterImplementsIDisposable()
        {
            var factory = BuildFactory();
            var viewInstance = new View1();
            var presenter1 = factory.Create(typeof(DisposablePresenter), typeof(IView), viewInstance);

            var disposed = false;
            ((DisposablePresenter)presenter1).DisposeCallback =
                () => disposed = true;

            factory.Release(presenter1);

            Assert.IsTrue(disposed);
        }

        public class BasicPresenter : Presenter<IView>
        {
            public BasicPresenter(IView view)
                : base(view)
            {
            }
        }

        public class DisposablePresenter : Presenter<IView>, IDisposable
        {
            public DisposablePresenter(IView view)
                : base(view)
            {
            }

            public Action DisposeCallback { get; set; }

            public void Dispose()
            {
                DisposeCallback();
            }
        }

        public class View1 : IView
        {
            public bool ThrowExceptionIfNoPresenterBound
            {
                get { throw new NotImplementedException(); }
            }
            event EventHandler IView.Load
            {
                add { }
                remove { }
            }
        }
    }

}
