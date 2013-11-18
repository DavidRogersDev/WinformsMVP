using LicenceTracker.Entities;
using System.Linq;

namespace LicenceTracker.Services
{
    public interface ISoftwareService
    {
        void AddNewProduct(Software product);
        IQueryable<SoftwareType> GetSoftwareTypes();
    }
}
