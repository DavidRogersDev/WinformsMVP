using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsMvp.UnitTests.Views;
using WinFormsMvp.UnitTests.Models;

namespace WinFormsMvp.UnitTests.Presenters
{
    public class MainEntryMenuPresenter : Presenter<IMainView>
    {
        public MainEntryMenuPresenter(IMainView view)
            : base(view)
        {
            View.CloseFormClicked += new EventHandler(View_CloseFormClicked);
            View.DisplayCreateProjectView += new EventHandler(view_DisplayCreateProjectView);
            View.Load += new EventHandler(View_Load);
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
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
