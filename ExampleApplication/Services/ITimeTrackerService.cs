using System;
using System.Linq;
using ExampleApplication.ExampleData;

namespace ExampleApplication.Services
{
    public interface ITimeTrackerService
    {
        void CreateNewProject(string name, bool visibility, string description = null);
        //void CreateNewTask(string name, bool visibility, Project project, string description = null);
        //void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null);
        //void DeleteProject(Project project);
        //IQueryable<Project> GetListOfProjects();
        //IQueryable<Project> GetListOfVisibleProjects();
        //IQueryable<Task> GetTasksOfProject(int projectId);
        //IQueryable<Work> GetWorkItemsOfTask(int taskId);
        //void UpdateProject(Project project);
    }
}