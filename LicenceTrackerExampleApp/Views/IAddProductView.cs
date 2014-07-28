using System;
using System.Collections.Generic;
using WinFormsMvp;

namespace LicenceTracker.Views
{
    public interface IAddProductView : IView
    {
        event EventHandler CloseFormClicked;
        event EventHandler AddProductClicked;

        int Id { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        int TypeId { get; set; }
        Dictionary<int, string> SoftwareTypes { get; set; }

        void Exit();
    }
}
