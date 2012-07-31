namespace WinFormsMvp
{
    /// <summary>
    /// Defines the different modes through which presenters and views may be related.
    /// </summary>
    public enum BindingMode
    {
        /// <summary>
        /// A separate presenter is created for each applicable view.
        /// </summary>
        Default,

        /// <summary>
        /// A single presenter instance is created and bound to all of the applicable views.
        /// The presenter sees only a single view, however this is a composite view that
        /// proxies calls to each of the underlying views. See:
        /// http://wiki.webformsmvp.com/index.php?title=Feature_walkthroughs#Shared_Presenters
        /// </summary>
        SharedPresenter
    }
}