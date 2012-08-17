using System;
using System.Linq;
using SampleApp.Ioc;
using SampleApp.Models;
using SampleApp.Services;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
{
    public class ManageAllDataPresenter : Presenter<IAllDataView>
    {
        private readonly ITimeTrackerService timeTrackerService;


        public ManageAllDataPresenter(IAllDataView view) : base(view)
        {
            timeTrackerService = ServiceLocator.Resolve<ITimeTrackerService>();
            View.Load += new EventHandler(View_Load);
            View.ProjectHasBeenSelected += new EventHandler(View_ProjectHasBeenSelected);
            View.TaskHasBeenSelected += new EventHandler(View_TaskHasBeenSelected);
        }

        void View_TaskHasBeenSelected(object sender, EventArgs e)
        {
            View.PopulateWorkItemsByTaskId(timeTrackerService.GetWorkItemsOfTask((int)View.Model.SelectedTask.Id).ToList());
        }

        void View_ProjectHasBeenSelected(object sender, EventArgs e)
        {
            View.PopulateTasksByProjectId(timeTrackerService.GetTasksOfProject((int)View.Model.SelectedProject.Id).ToList());
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new ViewAllWorkModel
                             {
                                 Projects = timeTrackerService.GetListOfProjects().ToList()
                             };
        }

    }
}
