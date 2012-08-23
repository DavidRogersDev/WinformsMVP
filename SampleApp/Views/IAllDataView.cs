using System;
using System.Collections.Generic;
using SampleApp.ExampleData;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface IAllDataView : IView<ViewAllWorkModel>
    {
        event EventHandler ProjectDeleteSelected;
        event EventHandler ProjectHasBeenSelected;
        event EventHandler ProjectVisibilityToggled;
        event EventHandler TaskHasBeenSelected;

        void PopulateProjects(IList<Project> projects);
        void PopulateTasksByProjectId(IList<Task> tasksOfSelectedProject);
        void PopulateWorkItemsByTaskId(IList<Work> workItemsOfSelectedProject);
    }
}
