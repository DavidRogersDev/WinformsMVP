using System;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface ICreateWorkItemView : IView<CreateWorkItemModel>
    {
        event EventHandler ProjectedSelectionChanged;
        event EventHandler TaskSelectionChanged;
        event EventHandler AddWorkItemClicked;
        event EventHandler CloseFormClicked;

        void CloseForm();
    }
}
