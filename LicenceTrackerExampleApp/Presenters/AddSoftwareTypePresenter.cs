using LicenceTracker.Entities;
using LicenceTracker.Models;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class AddSoftwareTypePresenter : Presenter<IAddSoftwareTypeView>
    {
        ISoftwareService softwareService;
        public AddSoftwareTypePresenter(IAddSoftwareTypeView view)
            : base(view)
        {
            View.AddProductClicked += View_AddProductClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
            softwareService = new SoftwareService();
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new AddSoftwareTypeModel { NewSoftwareType = new SoftwareType() };
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
        }

        void View_AddProductClicked(object sender, EventArgs e)
        {
            softwareService.AddSoftwareType(View.Model.NewSoftwareType);
        }
    }
}
