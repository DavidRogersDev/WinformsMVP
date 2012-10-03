using System;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface ICreateTaskView : IView<CreateTaskModel>
    {
        event EventHandler AddTaskClicked;
        event EventHandler CloseFormClicked;

        void CloseForm();

    }
}
