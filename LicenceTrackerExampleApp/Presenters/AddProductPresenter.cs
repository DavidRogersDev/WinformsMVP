using LicenceTracker.Entities;
using LicenceTracker.Models;
using LicenceTracker.Services;
using LicenceTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class AddProductPresenter : Presenter<IAddProductView>
    {
        private readonly ISoftwareService softwareService;
        private AddProductModel model;

        public AddProductPresenter(IAddProductView view)
            : base(view)
        {
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
            View.AddProductClicked += View_AddProductClicked;
            softwareService = new SoftwareService();
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
            softwareService.AddNewProduct(model.NewSoftwareProduct);
            View.Id = model.NewSoftwareProduct.Id;
        }

        void View_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> softwareTypes = new Dictionary<int, string>(model.AllSoftwareTypes.Count);

            foreach (var bla in model.AllSoftwareTypes.Select(x => new KeyValuePair<int, string>(x.Id, x.Name)))
            {
                softwareTypes.Add(bla.Key, bla.Value);
            }

            View.SoftwareTypes = softwareTypes;
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
        }
    }
}
