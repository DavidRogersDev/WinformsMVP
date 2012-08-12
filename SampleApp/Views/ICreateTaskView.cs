using System;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface ICreateTaskView : IView<CreateTaskModel>
    {
        event EventHandler AddTaskClicked;
        event EventHandler CloseFormClicked;

        void CloseForm();

    }
}
