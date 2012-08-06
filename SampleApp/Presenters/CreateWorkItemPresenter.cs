using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
{
    public class CreateWorkItemPresenter : Presenter<ICreateWorkItemView>
    {
        public CreateWorkItemPresenter(ICreateWorkItemView view) : base(view)
        {
            View.Load += new EventHandler(View_Load);
            View.AddWorkItemClicked += new EventHandler(View_AddWorkItemClicked);
            View.ProjectedSelectionChanged += new EventHandler(View_ProjectedSelectionChanged);
            View.TaskSelectionChanged += new EventHandler(View_TaskSelectionChanged);
        }

        void View_TaskSelectionChanged(object sender, EventArgs e)
        {
            
        }

        void View_ProjectedSelectionChanged(object sender, EventArgs e)
        {
            
        }

        void View_AddWorkItemClicked(object sender, EventArgs e)
        {
            
        }

        void View_Load(object sender, EventArgs e)
        {
            
        }
    }
}
