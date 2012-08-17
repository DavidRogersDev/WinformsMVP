using System;
using SampleApp.Ioc;
using SampleApp.Models;
using SampleApp.Services;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
{
    public class CreateProjectPresenter : Presenter<ICreateProjectView>
    {
        private readonly ITimeTrackerService timeTrackerService;

        public CreateProjectPresenter(ICreateProjectView view)
            :base(view)
        {
            timeTrackerService = ServiceLocator.Resolve<ITimeTrackerService>();

            View.AddProjectClicked += new EventHandler(view_AddProjectClicked);
            View.CloseFormClicked += new EventHandler(View_CloseFormClicked);
            View.Load += new EventHandler(View_Load);
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.CloseForm();
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateProjectModel();
        }

        private void view_AddProjectClicked(object sender, EventArgs e)
        {
            timeTrackerService.CreateNewProject(View.Model.Name, View.Model.Visibilty, View.Model.Description);
        }
    }
}
