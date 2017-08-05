namespace WinFormsMvp
{
    public abstract class Presenter<TView> : IPresenter<TView>
        where TView : class, IView 
    {
        private readonly TView view;

        protected Presenter(TView view)
        {
            this.view = view;
        }

        public TView View
        {
            get { return view; }
        }

    }
}
