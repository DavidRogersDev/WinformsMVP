using System;
using WinFormsMvp;

namespace SimpleInjector.Views
{
    public interface IMainView : IView
    {
        event EventHandler LoadChildForm1;

        void LoadChildForm(Type childFormType);
    }
}