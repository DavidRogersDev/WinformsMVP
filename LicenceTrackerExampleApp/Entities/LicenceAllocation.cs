using System;

namespace LicenceTracker.Entities
{
    public class LicenceAllocation
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Licence Licence { get; set; }
        public int LicenceId { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
