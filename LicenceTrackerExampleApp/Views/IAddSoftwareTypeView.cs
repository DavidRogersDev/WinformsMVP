using LicenceTracker.Models;
using System;
using WinFormsMvp;

namespace LicenceTracker.Views
{
    public interface IAddSoftwareTypeView : IView<AddSoftwareTypeModel>
    {
        event EventHandler CloseFormClicked;
        event EventHandler AddProductClicked;
        
        void Exit();
    }
}
