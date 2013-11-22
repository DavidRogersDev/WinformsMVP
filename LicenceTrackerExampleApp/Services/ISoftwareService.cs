using LicenceTracker.Entities;
using System.Linq;

namespace LicenceTracker.Services
{
    public interface ISoftwareService
    {
        Person AddNewPerson(Person person);
        Software AddNewProduct(Software product);
        SoftwareType AddSoftwareType(SoftwareType softwareType);
        IQueryable<SoftwareType> GetSoftwareTypes();
    }
}
