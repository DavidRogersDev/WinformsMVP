using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.ExampleData;

namespace SampleApp.Models
{
    public class CreateTaskModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public IList<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public bool Visibilty { get; set; }
    }
}
