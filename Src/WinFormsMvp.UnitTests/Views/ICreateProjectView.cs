using System;
using WinFormsMvp;
using WinFormsMvp.UnitTests.Models;

namespace WinFormsMvp.UnitTests.Views
{
    public interface ICreateProjectView : IView<CreateProjectModel>
    {
        event EventHandler AddProjectClicked;
        event EventHandler CloseFormClicked;

        void CloseForm();

    }
}
