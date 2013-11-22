using LicenceTracker.Entities;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class AddPersonPresenter : Presenter<IAddPersonView>
    {
        private readonly ISoftwareService softwareService;
        public AddPersonPresenter(IAddPersonView view)
            :base(view)
        {
            View.CloseFormClicked += View_CloseFormClicked;
            View.AddPersonClicked += View_AddPersonClicked;
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model.NewPerson = new Person();
        }

        void View_AddPersonClicked(object sender, EventArgs e)
        {
            softwareService.AddNewPerson(View.Model.NewPerson);
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
        }
    }
}
