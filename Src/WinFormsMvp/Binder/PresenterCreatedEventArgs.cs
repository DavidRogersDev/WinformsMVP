using System;

namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Provides data for the <see cref="WebFormsMvp.Binder.PresenterBinder.PresenterCreated"/> event.
    /// </summary>
    public class PresenterCreatedEventArgs : EventArgs
    {
        readonly IPresenter presenter;

        /// <summary />
        /// <param name="presenter">The presenter that was just created.</param>
        public PresenterCreatedEventArgs(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        /// <summary>
        /// Gets the presenter that was just created.
        /// </summary>
        public IPresenter Presenter
        {
            get { return presenter; }
        }
    }
}