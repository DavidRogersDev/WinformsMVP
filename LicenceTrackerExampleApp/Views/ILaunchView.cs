using LicenceTracker.Models;
using System;
using WinFormsMvp;

namespace LicenceTracker.Views
{
    public interface ILaunchView : IView
    {
        event EventHandler CloseFormClicked;
        
        void Exit();
    }
}
