using System;
using WinFormsMvp.UnitTests.Models;

namespace WinFormsMvp.UnitTests.Views
{
    public interface ICreateTaskView : IView<CreateTaskModel>
    {
        event EventHandler CloseFormClicked;
        event EventHandler DisplayCreateProjectView;

        void DisplayView();
        void Exit();
    }
}
