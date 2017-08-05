namespace WinFormsMvp
{
    /// <summary>
    /// Defines the contract that composite view wrappers must expose.
    /// </summary>
    public interface ICompositeView : IView
    {
        /// <summary>
        /// Adds the specified view instance to the composite view collection.
        /// </summary>
        void Add(IView view);
    }
}
