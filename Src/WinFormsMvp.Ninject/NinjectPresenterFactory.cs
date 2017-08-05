using Ninject;
using Ninject.Parameters;
using System;
using System.Diagnostics;
using WinFormsMvp.Binder;

namespace WinFormsMvp.Ninject
{
    public class NinjectPresenterFactory : IPresenterFactory, IDisposable
    {
        /// <summary>
        /// Ninject kernel 
        /// </summary>
        protected IKernel Kernel;

        protected bool Disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectPresenterFactory"/> class.
        /// </summary>
        /// <param name="kernel">The <see cref="IKernel"/> to use within the presenter factory</param>
        public NinjectPresenterFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        #region IPresenterFactory Members

        /// <summary>
        /// Creates the specified presenter type.
        /// </summary>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <param name="viewType">Type of the view.</param>
        /// <param name="viewInstance">The view instance.</param>
        /// <returns></returns>
        public virtual IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var presenter = (IPresenter)Kernel.Get(
                presenterType, new IParameter[] { new ConstructorArgument("view", value: viewInstance) }
                );

            return presenter;
        }

        /// <summary>
        /// Releases the specified presenter.
        /// </summary>
        /// <param name="presenter">The presenter.</param>
        public virtual void Release(IPresenter presenter)
        {
            var released = Kernel.Release(presenter);

            Trace.WriteLine(string.Format("Presenter instance found and released by kernel {0}", released));

            var disposablePresenter = presenter as IDisposable;
            if (disposablePresenter != null)
                disposablePresenter.Dispose();
        }

        #endregion

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

            if (disposing && Kernel != null)
            {
                Kernel.Dispose();
                Kernel = null;
                Disposed = true;
            }
        }

        #endregion

    }
}
