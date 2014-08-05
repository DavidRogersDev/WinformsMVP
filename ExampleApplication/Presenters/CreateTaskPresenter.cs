using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace ExampleApplication.Presenters
{
    public class CreateTaskPresenter : Presenter<ICreateTaskView>, IDisposable
    {
        private readonly ITimeTrackerService _timeTrackerService;
        private bool _disposed;

        public CreateTaskPresenter(ICreateTaskView view, ITimeTrackerService timeTrackerService)
            : base(view)
        {
            _timeTrackerService = timeTrackerService;

            View.Load += View_Load;
            View.CloseFormClicked += View_CloseFormClicked;
            View.AddTaskClicked += View_AddTaskClicked;
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
            PresenterBinder.Factory.Release(this);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateTaskModel();
        }

        private void View_AddTaskClicked(object sender, EventArgs e)
        {
            _timeTrackerService.CreateNewTask(View.Model.Name, View.Model.Visibilty, View.Model.SelectedProject, View.Model.Estimate, View.Model.Description);
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
