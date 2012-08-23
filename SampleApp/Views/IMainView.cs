using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface IMainView : IView<MainFormModel>
    {
        event EventHandler DisplayCreateProjectView;

        void DisplayView();
        void Exit();
    }
}
