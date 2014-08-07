using System.Collections.Generic;


namespace ExampleApplication.DataAccess.EF
{
    public partial class Project
    {
        public Project()
        {
            this.Tasks = new List<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
