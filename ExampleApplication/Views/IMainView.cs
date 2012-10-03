using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface IMainView : IView<MainFormModel>
    {
        event EventHandler CloseFormClicked;
        event EventHandler DisplayCreateProjectView;

        void DisplayView();
        void Exit();
    }
}
