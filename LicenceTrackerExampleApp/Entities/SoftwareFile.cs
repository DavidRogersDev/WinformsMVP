using LicenceTracker.Entities.Enums;

namespace LicenceTracker.Entities
{
    public class SoftwareFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public FileTypes FileType { get; set; }
        public Software Software { get; set; }
        public int SoftwareId { get; set; }
    }
}
