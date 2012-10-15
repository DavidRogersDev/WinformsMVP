using System;
using System.Linq;
using ExampleApplication.Ioc;
using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using WinFormsMvp;

namespace ExampleApplication.Presenters
{
    public class CreateWorkItemPresenter : Presenter<ICreateWorkItemView>
    {
        private readonly ITimeTrackerService timeTrackerService;

        public CreateWorkItemPresenter(ICreateWorkItemView view) : base(view)
        {
            timeTrackerService = ServiceLocator.Resolve<ITimeTrackerService>();

            View.Load += new EventHandler(View_Load);
            View.CloseFormClicked += new EventHandler(View_CloseFormClicked);
            View.AddWorkItemClicked += new EventHandler(View_AddWorkItemClicked);
            View.ProjectedSelectionChanged += new EventHandler(View_ProjectedSelectionChanged);
            View.TaskSelectionChanged += new EventHandler(View_TaskSelectionChanged);
        }

        private void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateWorkItemModel();
            try
            {
                View.Model.Projects = timeTrackerService.GetListOfVisibleProjects().ToList();
            }
            catch
            {
                
            }
        }

        private void View_TaskSelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void View_ProjectedSelectionChanged(object sender, EventArgs e)
        {
            View.Model.Tasks = timeTrackerService.GetTasksOfProject((int)View.Model.SelectedProject.Id).ToList();
        }

        private void View_AddWorkItemClicked(object sender, EventArgs e)
        {
            timeTrackerService.CreateNewWorkItem(View.Model.SelectedTask, View.Model.Duration, View.Model.DateOfWork, View.Model.Description);
        }


    }
}
