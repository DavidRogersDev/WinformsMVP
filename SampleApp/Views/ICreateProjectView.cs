using System;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface ICreateProjectView : IView<CreateProjectModel>
    {
        event EventHandler AddProjectClicked;
    }
}
