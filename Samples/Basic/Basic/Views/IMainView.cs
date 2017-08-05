using System;

namespace Basic.Views
{
    public interface IMainView : ICoreView
    {
        event EventHandler LoadChildForm1;
        event EventHandler LoadChildForm2;

        void ConfirmLoaded();
        void LoadChildForm(Type childFormType);
    }
}
