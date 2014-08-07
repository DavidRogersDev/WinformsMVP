using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using System;
using System.Linq;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace ExampleApplication.Presenters
{
    public class ManageAllDataPresenter : Presenter<IAllDataView>, IDisposable
    {
        private readonly ITimeTrackerService _timeTrackerService;
        private bool _disposed;

        public ManageAllDataPresenter(IAllDataView view, ITimeTrackerService timeTrackerService)
            : base(view)
        {
            _timeTrackerService = timeTrackerService;
            View.CloseFormClicked += View_CloseFormClicked;
            View.ProjectDeleteSelected += View_ProjectDeleteSelected;
            View.Load += View_Load;
            View.ProjectHasBeenSelected += View_ProjectHasBeenSelected;
            View.ProjectVisibilityToggled += View_ProjectVisibilityToggled;
            View.TaskHasBeenSelected += View_TaskHasBeenSelected;
            View.TaskDeleteSelected += View_TaskDeleteSelected;
            View.TaskVisibilityToggled += View_TaskVisibilityToggled;
            View.WorkItemDeleteSelected += View_WorkItemDeleteSelected;
        }

        private void View_CloseFormClicked(object sender, EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        void View_WorkItemDeleteSelected(object sender, Custom.SelectedWorkItemEventArgs e)
        {
            _timeTrackerService.DeleteWorkItem(e.SelectedWorkItem);
            View.PopulateWorkItemsByTaskId(_timeTrackerService.GetWorkItemsOfTask((int)View.Model.SelectedTask.Id).ToList());
        }

        void View_TaskVisibilityToggled(object sender, EventArgs e)
        {
            _timeTrackerService.UpdateTask(View.Model.SelectedTask);
            View.PopulateTasksByProjectId(_timeTrackerService.GetTasksOfProject(View.Model.SelectedProject.Id).ToList());
        }

        void View_TaskDeleteSelected(object sender, EventArgs e)
        {
            _timeTrackerService.DeleteTask(View.Model.SelectedTask);
            View.PopulateTasksByProjectId(_timeTrackerService.GetTasksOfProject((int)View.Model.SelectedProject.Id).ToList());
        }

        void View_ProjectVisibilityToggled(object sender, EventArgs e)
        {
            _timeTrackerService.UpdateProject(View.Model.SelectedProject);
            View.PopulateProjects(_timeTrackerService.GetListOfProjects().ToList());
        }

        void View_ProjectDeleteSelected(object sender, EventArgs e)
        {
            _timeTrackerService.DeleteProject(View.Model.SelectedProject);
            View.PopulateProjects(_timeTrackerService.GetListOfVisibleProjects().ToList());
        }

        void View_TaskHasBeenSelected(object sender, EventArgs e)
        {
            View.PopulateWorkItemsByTaskId(_timeTrackerService.GetWorkItemsOfTask((int)View.Model.SelectedTask.Id).ToList());
        }

        void View_ProjectHasBeenSelected(object sender, EventArgs e)
        {
            View.PopulateTasksByProjectId(_timeTrackerService.GetTasksOfProject((int)View.Model.SelectedProject.Id).ToList());
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new ViewAllWorkModel
                             {
                                 Projects = _timeTrackerService.GetListOfProjects().ToList()
                             };
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
                _timeTrackerService.Dispose();
                _disposed = true;
            }
        }

    }
}
