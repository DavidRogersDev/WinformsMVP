using System;
using System.Linq;

namespace ExampleApplication.Services
{
    public interface ITimeTrackerService
    {
        void CreateNewProject(string name, bool visibility, string description = null);
        void CreateNewTask(string name, bool visibility, Project project, decimal estimate, string description = null);
        void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null);
        void DeleteProject(Project project);
        void DeleteTask(Task task);
        void DeleteWorkItem(Work work);
        IQueryable<Project> GetListOfProjects();
        IQueryable<Project> GetListOfVisibleProjects();
        IQueryable<Task> GetTasksOfProject(int projectId);
        IQueryable<Task> GetVisibleTasksOfProject(int taskId);
        IQueryable<Work> GetWorkItemsOfTask(int taskId);
        void UpdateProject(Project project);
        void UpdateTask(Task project);
    }
}