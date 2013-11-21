using LicenceTracker.Entities;
using System.Linq;

namespace LicenceTracker.Services
{
    public interface ISoftwareService
    {
        void AddNewProduct(Software product);
        SoftwareType AddSoftwareType(SoftwareType softwareType);
        IQueryable<SoftwareType> GetSoftwareTypes();
    }
}
