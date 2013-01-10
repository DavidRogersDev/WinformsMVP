using System;
using System.Linq;
using ExampleApplication.Ioc;
using ExampleApplication.Models;
using ExampleApplication.Services;
using ExampleApplication.Views;
using WinFormsMvp;

namespace ExampleApplication.Presenters
{
    public class ChooseProjectPresenter : Presenter<IProjectChooser>
    {
        private readonly ITimeTrackerService timeTrackerService;

        public ChooseProjectPresenter(IProjectChooser view) : base(view)
        {
            timeTrackerService = ServiceLocator.Resolve<ITimeTrackerService>();

            View.Load += new EventHandler(View_Load);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new ChooseProjectModel();
            View.Model.Projects = timeTrackerService.GetListOfVisibleProjects().ToList();
        }
    }
}
