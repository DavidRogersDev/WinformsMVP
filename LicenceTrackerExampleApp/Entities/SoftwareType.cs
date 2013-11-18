
using System.Collections.Generic;
namespace LicenceTracker.Entities
{
    public class SoftwareType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        public virtual ICollection<Software> SoftwareProducts { get; set; }
    }
}
