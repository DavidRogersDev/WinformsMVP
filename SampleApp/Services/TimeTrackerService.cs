using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
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

        public IQueryable<Project> GetListOfProjects()
        {
            return unitOfWork.GetAllProjects();
        }
    }
}
