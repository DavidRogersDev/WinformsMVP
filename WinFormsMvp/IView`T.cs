namespace WinFormsMvp
{
    public interface IView<TModel> : IView
    {
        TModel Model { get; set; }
    }
}
