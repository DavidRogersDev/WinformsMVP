using System.Collections.Generic;


namespace ExampleApplication.DataAccess.EF
{
    public partial class Task
    {
        public Task()
        {
            this.Works = new List<Work>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public bool Visible { get; set; }
        public decimal Estimate { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
