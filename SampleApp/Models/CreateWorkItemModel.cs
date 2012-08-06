using System.Collections.Generic;
using SampleApp.ExampleData;

namespace SampleApp.Models
{
    public class CreateWorkItemModel
    {
        public IList<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public Task SelectedTask { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
