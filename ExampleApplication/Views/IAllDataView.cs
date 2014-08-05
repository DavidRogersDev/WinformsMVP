using System;
using System.Collections.Generic;
using ExampleApplication.Custom;
using ExampleApplication.DataAccess.EF;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface IAllDataView : IView<ViewAllWorkModel>
    {
        event EventHandler CloseFormClicked;
        event EventHandler ProjectDeleteSelected;
        event EventHandler ProjectHasBeenSelected;
        event EventHandler ProjectVisibilityToggled;
        event EventHandler TaskHasBeenSelected;
        event EventHandler TaskDeleteSelected;
        event EventHandler TaskVisibilityToggled;
        event EventHandler<SelectedWorkItemEventArgs> WorkItemDeleteSelected;

        void CloseForm();
        void PopulateProjects(IList<Project> projects);
        void PopulateTasksByProjectId(IList<Task> tasksOfSelectedProject);
        void PopulateWorkItemsByTaskId(IList<Work> workItemsOfSelectedProject);
    }
}
