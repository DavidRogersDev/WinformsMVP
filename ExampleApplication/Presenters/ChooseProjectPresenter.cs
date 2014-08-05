using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using System;
using System.Linq;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace ExampleApplication.Presenters
{
    public class ChooseProjectPresenter : Presenter<IProjectChooser>, IDisposable
    {
        private readonly ITimeTrackerService _timeTrackerService;
        private bool _disposed;

        public ChooseProjectPresenter(IProjectChooser view, ITimeTrackerService timeTrackerService) : base(view)
        {
            _timeTrackerService = timeTrackerService;

            View.CloseControl += View_CloseControl;
            View.Load += View_Load;
        }

        void View_CloseControl(object sender, EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new ChooseProjectModel();
            View.Model.Projects = _timeTrackerService.GetListOfVisibleProjects().ToList();
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
