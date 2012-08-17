using System;
using System.Collections.Generic;
using SampleApp.ExampleData;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface IAllDataView : IView<ViewAllWorkModel>
    {
        event EventHandler ProjectHasBeenSelected;
        event EventHandler TaskHasBeenSelected;

        void PopulateTasksByProjectId(IList<Task> tasksOfSelectedProject);
        void PopulateWorkItemsByTaskId(IList<Work> workItemsOfSelectedProject);
    }
}
