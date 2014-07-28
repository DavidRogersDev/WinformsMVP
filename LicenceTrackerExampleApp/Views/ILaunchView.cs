using System;
using System.ComponentModel;
using WinFormsMvp;

namespace LicenceTracker.Views
{
    public interface ILaunchView : IView
    {
        event EventHandler CloseFormClicked;
        event EventHandler AddPersonClicked;
        event EventHandler AddSoftwareClicked;

        BindingList<LogEvent> LiveLog { get; set; }

        void ShowAddPersonView();
        void ShowAddProductView();
        void Exit();

    }
}
