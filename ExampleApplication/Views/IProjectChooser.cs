using System;
using System.Windows.Forms.VisualStyles;
using ExampleApplication.DataAccess.EF;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface IProjectChooser : IView<ChooseProjectModel>
    {
        event EventHandler CloseControl;
        void Exit();
        Project SelectedProject { get; }
    }
}
