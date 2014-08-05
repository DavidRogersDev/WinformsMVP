using System.Collections.Generic;


namespace ExampleApplication.DataAccess.EF
{
    public partial class Task
    {
        public Task()
        {
            this.Works = new List<Work>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int projectId { get; set; }
        public bool visible { get; set; }
        public decimal estimate { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
