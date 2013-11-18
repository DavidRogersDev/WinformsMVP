
using LicenceTracker.Entities;
using System.Collections.Generic;
using System.Data.Entity;
namespace LicenceTracker.Db
{
    public class LicenceTrackerInitializer : DropCreateDatabaseAlways<LicenceTrackerContext>
    {
        protected override void Seed(LicenceTrackerContext context)
        {
            new List<Person> { new Person { FirstName = "Terry", LastName = "Halpin" } }.ForEach(p => context.People.Add(p));
            new List<SoftwareType> 
                { 
                    new SoftwareType { Description = "Desktop Operating System", Name = "DesktopOS" } ,
                    new SoftwareType { Description = "Server Operating System", Name = "ServerOS" } 
                }
                .ForEach(s => context.SoftwareTypes.Add(s));

            base.Seed(context);
        }
    }
}
