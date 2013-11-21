using LicenceTracker.Models;
using System;
using WinFormsMvp;

namespace LicenceTracker.Views
{
    public interface ILaunchView : IView
    {
        event EventHandler CloseFormClicked;
        event EventHandler AddPersonClicked;
        event EventHandler AddSoftwareClicked;

        void ShowAddPersonView();
        void ShowAddProductView();
        void Exit();

    }
}
