using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Models;
using SampleApp.Views;
using WinFormsMvp;

namespace SampleApp.Presenters
{
    public class MainEntryMenuPresenter : Presenter<IMainView>
    {
        public MainEntryMenuPresenter(IMainView view) : base(view)
        {
            View.DisplayCreateProjectView += new EventHandler(view_DisplayCreateProjectView);
            View.Load += new EventHandler(View_Load);
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new MainFormModel();
        }



        void view_DisplayCreateProjectView(object sender, EventArgs e)
        {
            View.DisplayView();
        }
    }
}
