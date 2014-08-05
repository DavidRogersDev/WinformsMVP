using ExampleApplication.DataAccess.EF;
using System;
using System.Collections.Generic;

namespace ExampleApplication.Services
{
    public interface ITimeTrackerService : IDisposable
    {
        void CreateNewProject(string name, bool visibility, string description = null);
        void CreateNewTask(string name, bool visibility, Project project, decimal estimate, string description = null);
        void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null);
        void DeleteProject(Project project);
        void DeleteTask(Task task);
        void DeleteWorkItem(Work work);
        IEnumerable<Project> GetListOfProjects();
        IEnumerable<Project> GetListOfVisibleProjects();
        IEnumerable<Task> GetTasksOfProject(int projectId);
        IEnumerable<Task> GetVisibleTasksOfProject(int taskId);
        IEnumerable<Work> GetWorkItemsOfTask(int taskId);
        void UpdateProject(Project project);
        void UpdateTask(Task project);
    }
}