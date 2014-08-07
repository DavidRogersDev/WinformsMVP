using ExampleApplication.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExampleApplication.Services
{
    public class TimeTrackerService : ITimeTrackerService
    {
        private readonly TimetrackerContext _context;
        private bool _disposed;

        public TimeTrackerService()
        {
            _context = new TimetrackerContext();
        }

        public void CreateNewProject(string name, bool visibility, string description = null)
        {
            var newProject = new Project
            {
                Name = name,
                Description = description,
                Visible = visibility
            };

            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public void CreateNewTask(string name, bool visibility, Project project, decimal estimate,
                                  string description = null)
        {
            var newTask = new Task
            {
                Name = name,
                Description = description,
                Visible = visibility,
                ProjectId = project.Id,
                Estimate = estimate
            };

            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void CreateNewWorkItem(Task task, double duration, DateTime dateOfWork, string description = null)
        {
            var newWork = new Work
            {
                Task = task, 
                Description = description,
                Duration = (decimal)duration,
                DateOfWork = dateOfWork
            };

            _context.Works.Add(newWork);
            _context.SaveChanges();

        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void DeleteWorkItem(Work work)
        {
            _context.Works.Remove(work);
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetListOfProjects()
        {
            return _context.Projects;
        }


        public IEnumerable<Project> GetListOfVisibleProjects()
        {
            return _context.Projects.Where(p => p.Visible);
        }

        public IEnumerable<Task> GetTasksOfProject(int projectId)
        {
            return _context.Tasks.Where(t => t.ProjectId == projectId);
        }

        public IEnumerable<Task> GetVisibleTasksOfProject(int projectId)
        {
            return _context.Tasks.Where(task => task.ProjectId == projectId && task.Visible);

        }

        public IEnumerable<Work> GetWorkItemsOfTask(int taskId)
        {
            return _context.Works.Where(w => w.TaskId == taskId);
        }

        public void UpdateProject(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
