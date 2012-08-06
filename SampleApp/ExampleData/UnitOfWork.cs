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

        public UnitOfWork(ObjectContext entities)
        {
            context = entities;
            projectRepository = new ProjectRepository(context);
            taskRepository = new TaskRepository(context);
        }

        //public UnitOfWork(ObjectContext entities, TaskRepository taskRepository, ProjectRepository projectRepository, WorkRepository workRepository)
        //{
        //    this.context = entities as TimeTrackerEntities;
        //    this.projectRepository = projectRepository;
        //    this.taskRepository = taskRepository;
        //    this.workRepository = workRepository;
        //}

        public void CreateNewProject(string name, bool visibility, string description = null)
        {
            var newProject = new Project { name = name, description = description, visible = visibility };
            projectRepository.Add(newProject);
            projectRepository.SaveChanges();
        }

        public void CreateNewTask(string name, bool visibility, Project project, string description = null)
        {
            var newTask = new Task {  name = name, description = description, Project = project, visible = visibility };
            taskRepository.Add(newTask);
            taskRepository.SaveChanges();
        }

         public IQueryable<Project> GetAllProjects()
         {
             return projectRepository.GetAllAsQueryable();
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
