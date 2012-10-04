using System;
using ExampleApplication.Models;
using ExampleApplication.Views;
using WinFormsMvp;

namespace ExampleApplication.Presenters
{
    public class MainEntryMenuPresenter : Presenter<IMainView>
    {
        public MainEntryMenuPresenter(IMainView view) : base(view)
        {
            View.CloseFormClicked += View_CloseFormClicked;
            View.DisplayCreateProjectView += view_DisplayCreateProjectView;
            View.Load += View_Load;
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
