namespace WinFormsMvp
{
    public interface IPresenter
    {
        /// <summary>
        /// Gets or sets the message bus used for cross presenter messaging.
        /// </summary>
        IAppState Items { get; set; }

    }
}
