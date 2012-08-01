using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using SampleApp.ExampleData;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed;
        private ObjectContext context;

        public UnitOfWork(ObjectContext entities)
        {
            context = entities;
        }

        //public UnitOfWork(ObjectContext entities, TaskRepository taskRepository, ProjectRepository projectRepository, WorkRepository workRepository)
        //{
        //    this.context = entities as TimeTrackerEntities;
        //    this.projectRepository = projectRepository;
        //    this.taskRepository = taskRepository;
        //    this.workRepository = workRepository;
        //}


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
