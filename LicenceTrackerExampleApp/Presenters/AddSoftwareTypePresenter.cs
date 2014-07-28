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
    public class AddSoftwareTypePresenter : Presenter<IAddSoftwareTypeView>, IDisposable
    {
        readonly ISoftwareService _softwareService;
        public AddSoftwareTypePresenter(IAddSoftwareTypeView view, ISoftwareService softwareService)
            : base(view)
        {
            View.AddProductClicked += View_AddProductClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
            _softwareService = softwareService;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new AddSoftwareTypeModel { NewSoftwareType = new SoftwareType() };
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
            PresenterBinder.Factory.Release(this);
        }

        void View_AddProductClicked(object sender, EventArgs e)
        {
            _softwareService.AddSoftwareType(View.Model.NewSoftwareType);

            PresenterBinder.MessageBus.Send(
                new GenericMessage<SoftwareType>(View.Model.NewSoftwareType), Constants.SoftwareTypeAddedToken);
        }

        public void Dispose()
        {
            var disposableService = _softwareService as IDisposable;
            if (disposableService != null)
                disposableService.Dispose();
        }
    }
}
