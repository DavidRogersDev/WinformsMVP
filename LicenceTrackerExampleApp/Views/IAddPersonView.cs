using LicenceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
