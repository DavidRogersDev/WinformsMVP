using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace ExampleApplication.DataAccess
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

        public void CreateNewTask(string name, bool visibility, Project project, decimal estimate, string description = null)
        {
            
            var newTask = new Task {  Name = name, Description = description, Project = project, Estimate = estimate, Visible = visibility };
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
                                      Duration = (decimal)duration
                                  };
            workRepository.Add(newWorkItem);
            workRepository.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            //  Not the best way to cascade a delete, but it'll do for this sample app.
            ((WorkRepository)workRepository).DeleteWorkItems(project.Tasks.SelectMany(t => t.Works).ToList());
            ((TaskRepository)taskRepository).DeleteTasks(new List<Task>(project.Tasks));
            projectRepository.Delete(project);
            projectRepository.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        }

        public void DeleteTask(Task task)
        {
            taskRepository.Delete(task);
            taskRepository.SaveChanges();
        }

        public void DeleteWorkItem(Work work)
        {
            workRepository.Delete(work);
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

        public void UpdateProject(Project project)
        {
            //  do nothing with the project. Saving changes on the context pushes the update back to the server. 
            //  Note: not good code to use entities in the View. But great for simple demo examples.
            context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            //  do nothing with the task. Saving changes on the context pushes the update back to the server. 
            //  Note: not good code to use entities in the View. But great for simple demo examples.
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
