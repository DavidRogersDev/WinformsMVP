using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using SampleApp.ExampleData;

namespace SampleApp.ExampleData
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed;
        private ObjectContext context;
        private IGenericRepository<Project> projectRepository;
        private IGenericRepository<Task> taskRepository;
        private IGenericRepository<Work> workRepository;

        public UnitOfWork(ObjectContext entities)
        {
            context = entities;
            projectRepository = new ProjectRepository(context);
            taskRepository = new TaskRepository(context);
            workRepository = new WorkRepository(context);
        }

        public void CreateNewProject(string name, bool visibility, string description = null)
        {
            var newProject = new Project { Name = name, Description = description, Visible = visibility };
            projectRepository.Add(newProject);
            projectRepository.SaveChanges();
        }

        public void CreateNewTask(string name, bool visibility, Project project, string description = null)
        {
            var newTask = new Task {  Name = name, Description = description, Project = project, Visible = visibility };
            taskRepository.Add(newTask);
            taskRepository.SaveChanges();
        }

        public void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null)
        {
            var newWorkItem = new Work
                                  {
                                      DateOfWork = dateOfWork,
                                      Task = task,
                                      Description = description,
                                      Duration = duration
                                  };
            workRepository.Add(newWorkItem);
            workRepository.SaveChanges();
        }

        public IQueryable<Project> GetAllProjects()
         {
             return projectRepository.GetAllAsQueryable();
         }

        public IQueryable<Task> GetTasksOfProject(int projectId)
        {
            return taskRepository.Find(t => t.ProjectId == projectId).AsQueryable();

        }

        public IQueryable<Work> GetWorkItemsOfTask(int taskId)
        {
            return workRepository.FindBy(w => w.TaskId == taskId, w => w.OrderBy(o => o.DateOfWork), string.Empty).AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
