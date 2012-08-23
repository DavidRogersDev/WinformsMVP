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
            View.ProjectDeleteSelected += new EventHandler(View_ProjectDeleteSelected);
            View.Load += new EventHandler(View_Load);
            View.ProjectHasBeenSelected += new EventHandler(View_ProjectHasBeenSelected);
            View.ProjectVisibilityToggled += new EventHandler(View_ProjectVisibilityToggled);
            View.TaskHasBeenSelected += new EventHandler(View_TaskHasBeenSelected);
        }

        void View_ProjectVisibilityToggled(object sender, EventArgs e)
        {
            timeTrackerService.UpdateProject(View.Model.SelectedProject);
            View.PopulateProjects(timeTrackerService.GetListOfProjects().ToList());
        }

        void View_ProjectDeleteSelected(object sender, EventArgs e)
        {
            timeTrackerService.DeleteProject(View.Model.SelectedProject);
            View.PopulateProjects(timeTrackerService.GetListOfVisibleProjects().ToList());
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
