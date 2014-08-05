using System.Collections.Generic;
using ExampleApplication.DataAccess.EF;

namespace ExampleApplication.Models
{
    public class CreateTaskModel
    {
        public string Description { get; set; }
        public decimal Estimate { get; set; }
        public string Name { get; set; }
        public IList<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public bool Visibilty { get; set; }
    }
}
