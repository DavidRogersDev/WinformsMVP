using LicenceTracker.Entities;
using LicenceTracker.Models;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class AddSoftwareTypePresenter : Presenter<IAddSoftwareTypeView>, IDisposable
    {
        ISoftwareService softwareService;
        public AddSoftwareTypePresenter(IAddSoftwareTypeView view, ISoftwareService softwareService)
            : base(view)
        {
            View.AddProductClicked += View_AddProductClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
            this.softwareService = softwareService;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new AddSoftwareTypeModel { NewSoftwareType = new SoftwareType() };
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit(this);
        }

        void View_AddProductClicked(object sender, EventArgs e)
        {
            softwareService.AddSoftwareType(View.Model.NewSoftwareType);
        }

        public void Dispose()
        {
            var disposableService = softwareService as IDisposable;
            if (disposableService != null)
                disposableService.Dispose();
        }
    }
}
