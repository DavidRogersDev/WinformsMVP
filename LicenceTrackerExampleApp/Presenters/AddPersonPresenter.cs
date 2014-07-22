using LicenceTracker.Entities;
using LicenceTracker.Models;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Messaging;

namespace LicenceTracker.Presenters
{
    public class AddPersonPresenter : Presenter<IAddPersonView>, IDisposable
    {
        private readonly ISoftwareService softwareService;
        public AddPersonPresenter(IAddPersonView view, ISoftwareService softwareService)
            :base(view)
        {
            this.softwareService = softwareService;
            View.CloseFormClicked += View_CloseFormClicked;
            View.AddPersonClicked += View_AddPersonClicked;
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new AddPersonModel { NewPerson = new Person() };

            var dave = "Hi i'm Dave";
        }

        void View_AddPersonClicked(object sender, EventArgs e)
        {
            softwareService.AddNewPerson(View.Model.NewPerson);

            //var bla = Items.GetItem<Software>("hi dave");

            PresenterBinder.MessageBus.Send(new GenericMessage<Person>(View.Model.NewPerson), Constants.MyToken);

        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit(this);
        }

        public void Dispose()
        {
            var disposableService = softwareService as IDisposable;
            if (disposableService != null)
                disposableService.Dispose();
        }
    }
}
