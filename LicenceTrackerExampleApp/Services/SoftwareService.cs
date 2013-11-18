using LicenceTracker.Db;
using LicenceTracker.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LicenceTracker.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly LicenceTrackerContext licenceTrackerContext;

        public SoftwareService()
        {
            licenceTrackerContext = new LicenceTrackerContext();
        }

        public void AddNewProduct(Software product)
        {
            var newProduct = licenceTrackerContext.SoftwareProducts.Add(product);
            licenceTrackerContext.SaveChanges();
        }

        public IQueryable<SoftwareType> GetSoftwareTypes()
        {
            return licenceTrackerContext.SoftwareTypes;
        }
    }
}
