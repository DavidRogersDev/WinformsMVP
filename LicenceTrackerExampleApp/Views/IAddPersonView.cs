using LicenceTracker.Models;
using System;
using WinFormsMvp;

namespace LicenceTracker.Views
{
   public interface IAddPersonView : IView<AddPersonModel>
    {
        event EventHandler CloseFormClicked;
        event EventHandler AddPersonClicked;

        void Exit();
    }
}
