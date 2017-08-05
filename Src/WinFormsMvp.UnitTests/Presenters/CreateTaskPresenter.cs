using WinFormsMvp.UnitTests.Views;

namespace WinFormsMvp.UnitTests.Presenters
{
    public class CreateTaskPresenter : Presenter<ICreateTaskView>
    {
        public CreateTaskPresenter(ICreateTaskView view) : base(view)
        {
        }
    }
}
