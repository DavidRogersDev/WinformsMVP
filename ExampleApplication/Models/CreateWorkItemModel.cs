using System;
using System.Collections.Generic;
using ExampleApplication.DataAccess.EF;

namespace ExampleApplication.Models
{
    public class CreateWorkItemModel
    {
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public IList<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public Task SelectedTask { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
