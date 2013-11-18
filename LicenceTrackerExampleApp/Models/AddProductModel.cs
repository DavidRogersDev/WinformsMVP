using LicenceTracker.Entities;
using System.Collections.Generic;

namespace LicenceTracker.Models
{
    public class AddProductModel
    {
        public Software NewSoftwareProduct { get; set; }
        public IList<SoftwareType> AllSoftwareTypes { get; set; }
    }
}
