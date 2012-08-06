using System;
using SampleApp.Models;
using WinFormsMvp;

namespace SampleApp.Views
{
    public interface ICreateWorkItemView : IView<CreateWorkItemModel>
    {
        event EventHandler ProjectedSelectionChanged;
        event EventHandler TaskSelectionChanged;
        event EventHandler AddWorkItemClicked;
    }
}
