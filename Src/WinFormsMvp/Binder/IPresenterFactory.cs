using System;

namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Defines the methods of a factory class capable of creating presenters.
    /// </summary>
    public interface IPresenterFactory
    {
        /// <summary>
        /// Creates a new instance of the specific presenter type, for the specified
        /// view type and instance.
        /// </summary>
        /// <param name="presenterType">The type of presenter to create.</param>
        /// <param name="viewType">The type of the view as defined by the binding that matched.</param>
        /// <param name="viewInstance">The view instance to bind this presenter to.</param>
        /// <returns>An instantitated presenter.</returns>
        IPresenter Create(Type presenterType, Type viewType, IView viewInstance);

        /// <summary>
        /// Releases the specified presenter from any of its lifestyle demands.
        /// This method's activities are implementation specific - for example,
        /// an IoC based factory would return the presenter to the container.
        /// </summary>
        /// <param name="presenter">The presenter to release.</param>
        void Release(IPresenter presenter);
    }
}