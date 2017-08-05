using System.Collections.Generic;

namespace SimpleInjector.Services
{
    public interface IPeopleManagerService
    {
        IEnumerable<Person> GetPeople();
    }
}
