using System;

namespace ExampleApplication.Custom
{
    public class SelectedWorkItemEventArgs : EventArgs
    {
        public Work SelectedWorkItem { get; set; }

        public SelectedWorkItemEventArgs(Work selectedWorkItem)
        {
            SelectedWorkItem = selectedWorkItem;
        }
    }
}
