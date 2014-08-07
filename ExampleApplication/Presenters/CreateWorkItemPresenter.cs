using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using System;
using System.Linq;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace ExampleApplication.Presenters
{
    public class CreateWorkItemPresenter : Presenter<ICreateWorkItemView>, IDisposable
    {
        private readonly ITimeTrackerService _timeTrackerService;
        private bool _disposed;

        public CreateWorkItemPresenter(ICreateWorkItemView view, ITimeTrackerService timeTrackerService)
            : base(view)
        {
            _timeTrackerService = timeTrackerService;

            View.Load += View_Load;
            View.CloseFormClicked += View_CloseFormClicked;
            View.AddWorkItemClicked += View_AddWorkItemClicked;
            View.ProjectedSelectionChanged += View_ProjectedSelectionChanged;
            View.TaskSelectionChanged += View_TaskSelectionChanged;
        }

        private void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
            PresenterBinder.Factory.Release(this);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateWorkItemModel();
            try
            {
                View.Model.Projects = _timeTrackerService.GetListOfVisibleProjects().ToList();
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
            View.Model.Tasks = _timeTrackerService.GetVisibleTasksOfProject((int)View.Model.SelectedProject.Id).ToList();
        }

        private void View_AddWorkItemClicked(object sender, EventArgs e)
        {
            _timeTrackerService.CreateNewWorkItem(View.Model.SelectedTask, View.Model.Duration, View.Model.DateOfWork, View.Model.Description);
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
