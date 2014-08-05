using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace ExampleApplication.Presenters
{
    public class CreateProjectPresenter : Presenter<ICreateProjectView>, IDisposable
    {
        private readonly ITimeTrackerService _timeTrackerService;
        private bool _disposed;

        public CreateProjectPresenter(ICreateProjectView view, ITimeTrackerService timeTrackerService)
            :base(view)
        {
            _timeTrackerService = timeTrackerService;

            View.AddProjectClicked += view_AddProjectClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
        }

        private void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
            PresenterBinder.Factory.Release(this);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateProjectModel();
        }

        private void view_AddProjectClicked(object sender, EventArgs e)
        {
            _timeTrackerService.CreateNewProject(View.Model.Name, View.Model.Visibilty, View.Model.Description);
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
