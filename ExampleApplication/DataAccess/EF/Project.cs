using System.Collections.Generic;


namespace ExampleApplication.DataAccess.EF
{
    public partial class Project
    {
        public Project()
        {
            this.Tasks = new List<Task>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool visible { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
