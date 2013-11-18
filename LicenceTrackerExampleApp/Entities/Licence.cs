using System.Collections.Generic;

namespace LicenceTracker.Entities
{
   public class Licence
    {
       public int Id { get; set; }
       public string LicenceKey { get; set; }
       public Software Software { get; set; }
       public int SoftwareId { get; set; }

       public virtual ICollection<LicenceAllocation> LicenceAllocations { get; set; }
    }
}
