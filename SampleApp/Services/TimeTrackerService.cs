using System;
using System.Linq;
using SampleApp.ExampleData;

namespace SampleApp.Services
{
    public class TimeTrackerService : ITimeTrackerService
    {
        private UnitOfWork unitOfWork;

        public TimeTrackerService()
        {
            unitOfWork = new UnitOfWork(new ExampleData.TTEntities());
        }

        public void CreateNewProject(string name, bool visibility, string description = null)
        {
            unitOfWork.CreateNewProject(name, visibility, description);
        }

        public void CreateNewTask(string name, bool visibility, Project project, string description = null)
        {
            unitOfWork.CreateNewTask(name, visibility, project, description);
        }

        public void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null)
        {
            unitOfWork.CreateNewWorkItem(task, duration, dateOfWork, description);
        }

        public IQueryable<Task> GetTasksOfProject(int projectId)
        {
            return unitOfWork.GetTasksOfProject(projectId).Where(p => p.Visible);
        }

        public IQueryable<Work> GetWorkItemsOfTask(int taskId)
        {
            return unitOfWork.GetWorkItemsOfTask(taskId);
        }

        public IQueryable<Project> GetListOfProjects()
        {
            return unitOfWork.GetAllProjects().Where(p => p.Visible);
        }
    }
}
