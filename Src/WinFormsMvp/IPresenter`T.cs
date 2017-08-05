namespace WinFormsMvp
{
    public interface IPresenter<out TView> : IPresenter
        where TView : class, IView
    {
        TView View { get; }
    }
}