using System;
using System.Diagnostics;
using LicenceTracker.Entities;
using LicenceTracker.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Messaging;

namespace LicenceTracker.Presenters
{
    public class LaunchPresenter : Presenter<ILaunchView>
    {
        public LaunchPresenter(ILaunchView view)
            : base(view)
        {
            View.AddPersonClicked += View_AddPersonClicked;
            View.AddSoftwareClicked += View_AddSoftwareClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;

            PresenterBinder.MessageBus.Register(this, Constants.MyToken, new Action<GenericMessage<Person>>(DoIt));
        }

        private void DoIt(GenericMessage<Person> msg)
        {
            Trace.WriteLine(msg.Content.FirstName);
        }

        void View_AddSoftwareClicked(object sender, System.EventArgs e)
        {
            View.ShowAddProductView();
        }

        void View_AddPersonClicked(object sender, System.EventArgs e)
        {
            View.ShowAddPersonView();
        }

        void View_Load(object sender, System.EventArgs e)
        {
            
        }

        void View_CloseFormClicked(object sender, System.EventArgs e)
        {
            View.Exit();
        }
    }
}
