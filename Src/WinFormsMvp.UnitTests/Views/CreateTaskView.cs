using System;
using WinFormsMvp.UnitTests.Models;
using WinFormsMvp.UnitTests.Presenters;

namespace WinFormsMvp.UnitTests.Views
{
    [PresenterBinding(typeof(CreateTaskPresenter))]
    public class CreateTaskView : WinFormsMvp.Forms.MvpForm<CreateTaskModel>, ICreateTaskView
    {
        public event EventHandler CloseFormClicked;
        public event EventHandler DisplayCreateProjectView;

        public void DisplayView()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
