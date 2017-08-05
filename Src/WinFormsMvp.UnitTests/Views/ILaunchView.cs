using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsMvp.UnitTests.Views
{
    public interface ILaunchView : IView
    {
        event EventHandler CloseFormClicked;

        void Exit();
    }
}
