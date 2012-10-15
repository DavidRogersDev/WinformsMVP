using System.Collections.Generic;

namespace ExampleApplication.Models
{
    public class ViewAllWorkModel
    {
        public IList<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public Task SelectedTask { get; set; }
        public IList<Task> TasksOfProject { get; set; }
        public IList<Work> WorkItemsOfTask { get; set; }
    }
}
