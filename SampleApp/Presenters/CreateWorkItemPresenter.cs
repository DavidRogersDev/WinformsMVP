using System;
using System.Linq;
using SampleApp.Ioc;
using SampleApp.Models;
using SampleApp.Services;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
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

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateWorkItemModel();
            try
            {
                View.Model.Projects = timeTrackerService.GetListOfProjects().ToList();
            }
            catch
            {
                
            }
        }

        void View_TaskSelectionChanged(object sender, EventArgs e)
        {
            
        }

        void View_ProjectedSelectionChanged(object sender, EventArgs e)
        {
            View.Model.Tasks = timeTrackerService.GetTasksOfProject((int)View.Model.SelectedProject.Id).ToList();
        }

        void View_AddWorkItemClicked(object sender, EventArgs e)
        {
            timeTrackerService.CreateNewWorkItem(View.Model.SelectedTask, View.Model.Duration, View.Model.DateOfWork, View.Model.Description);
        }


    }
}
