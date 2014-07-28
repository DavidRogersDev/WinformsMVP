using System.Diagnostics;
using LicenceTracker.Entities;
using LicenceTracker.Models;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace LicenceTracker.Presenters
{
    public class AddProductPresenter : Presenter<IAddProductView>, IDisposable
    {
        private readonly ISoftwareService _softwareService;
        private AddProductModel model;

        public AddProductPresenter(IAddProductView view, ISoftwareService softwareService)
            : base(view)
        {
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
            View.AddProductClicked += View_AddProductClicked;
            _softwareService = softwareService;
            model = new AddProductModel { AllSoftwareTypes = softwareService.GetSoftwareTypes().ToList() };
        }

        void View_AddProductClicked(object sender, EventArgs e)
        {
            model.NewSoftwareProduct = new Software
            {
                Description = View.Description,
                Name = View.Name,
                TypeId = View.TypeId,
            };
            _softwareService.AddNewProduct(model.NewSoftwareProduct);
            View.Id = model.NewSoftwareProduct.Id;
        }

        void View_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> softwareTypes = new Dictionary<int, string>(model.AllSoftwareTypes.Count);

            foreach (var softwareType in model.AllSoftwareTypes.Select(x => new KeyValuePair<int, string>(x.Id, x.Name)))
            {
                softwareTypes.Add(softwareType.Key, softwareType.Value);
            }

            View.SoftwareTypes = softwareTypes;
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
            PresenterBinder.Factory.Release(this);
        }

        public void Dispose()
        {
            var disposableService = _softwareService as IDisposable;
            if (disposableService != null)
                disposableService.Dispose();
        }
    }
}
