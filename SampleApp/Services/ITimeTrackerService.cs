using System;
using System.Linq;
using SampleApp.ExampleData;

namespace SampleApp.Services
{
    public interface ITimeTrackerService
    {
        void CreateNewProject(string name, bool visibility, string description = null);
        void CreateNewTask(string name, bool visibility, Project project, string description = null);
        void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null);
        IQueryable<Project> GetListOfProjects();
        IQueryable<Task> GetTasksOfProject(int projectId);
        IQueryable<Work> GetWorkItemsOfTask(int taskId);
    }
}