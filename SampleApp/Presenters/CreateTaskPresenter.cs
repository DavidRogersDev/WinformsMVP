using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Ioc;
using SampleApp.Models;
using SampleApp.Services;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
{
    public class CreateTaskPresenter : Presenter<ICreateTaskView>
    {
        private ITimeTrackerService timeTrackerService;

        public CreateTaskPresenter(ICreateTaskView view)
            : base(view)
        {
            timeTrackerService = ServiceLocator.Resolve<ITimeTrackerService>();

            View.Load += new EventHandler(View_Load);
            View.AddTaskClicked += new EventHandler(View_AddTaskClicked);
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = new CreateTaskModel();
            View.Model.Projects = timeTrackerService.GetListOfProjects().ToList();
        }

        private void View_AddTaskClicked(object sender, EventArgs e)
        {
            timeTrackerService.CreateNewTask(View.Model.Name, View.Model.Visibilty, View.Model.SelectedProject, View.Model.Description);
        }
    }
}
