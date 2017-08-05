namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Defines that contract for classes that implement logic for finding relevant presenters given
    /// some hosts and some view instances.
    /// </summary>
    public interface IPresenterDiscoveryStrategy
    {
        /// <summary>
        /// Gets the presenter binding for passed views.
        /// </summary>
        /// <param name="viewInstance">A view instances (user control, form, ...).</param>
        PresenterDiscoveryResult GetBinding(IView viewInstance);
    }
}