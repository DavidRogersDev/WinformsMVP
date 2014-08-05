using System;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface ICreateProjectView : IView<CreateProjectModel>
    {
        event EventHandler AddProjectClicked;
        event EventHandler CloseFormClicked;

        void CloseForm();
    }
}
