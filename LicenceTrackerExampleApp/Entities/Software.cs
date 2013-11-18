using System.Collections.Generic;

namespace LicenceTracker.Entities
{
    public class Software
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public SoftwareType Type { get; set; }
        public int TypeId { get; set; }

        public virtual ICollection<SoftwareFile> SoftwareFiles { get; set; }
        public virtual ICollection<Licence> LicenceKeys { get; set; }
    }
}
