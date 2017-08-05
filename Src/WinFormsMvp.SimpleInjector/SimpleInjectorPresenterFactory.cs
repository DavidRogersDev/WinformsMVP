using System;
using System.Threading;
using SimpleInjector;
using WinFormsMvp.Binder;

namespace WinFormsMvp.SimpleInjector
{
    public class SimpleInjectorPresenterFactory : IPresenterFactory
    {
        private Container _container;
        private readonly ThreadLocal<IView> _currentView = new ThreadLocal<IView>();
        private bool Disposed;

        public SimpleInjectorPresenterFactory(Container container)
        {
            if (container == null) 
                throw new ArgumentNullException("container");

            _container = container;

            _container.ResolveUnregisteredType += (s, e) =>
            {
                if (typeof(IView).IsAssignableFrom(e.UnregisteredServiceType))
                {
                    e.Register(() => _currentView.Value);
                }
            };
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            _currentView.Value = viewInstance;

            try
            {
                return _container.GetInstance(presenterType) as IPresenter;
            }
            finally
            {
                // Clear the thread-local value to ensure
                // views can be disposed after the request ends.
                _currentView.Value = null;
            }
        }

        public virtual void Release(IPresenter presenter)
        {
            var disposablePresenter = presenter as IDisposable;
            if (disposablePresenter != null)
                disposablePresenter.Dispose();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing && _container != null)
            {
                _container.Dispose();
                _container = null;
                Disposed = true;
            }
        }

        #endregion
    }
}
