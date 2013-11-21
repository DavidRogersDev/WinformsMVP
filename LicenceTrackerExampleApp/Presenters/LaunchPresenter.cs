using LicenceTracker.Models;
using LicenceTracker.Views;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class LaunchPresenter : Presenter<ILaunchView>
    {
        public LaunchPresenter(ILaunchView view)
            : base(view)
        {
            View.AddPersonClicked += View_AddPersonClicked;
            View.AddSoftwareClicked += View_AddSoftwareClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
        }

        void View_AddSoftwareClicked(object sender, System.EventArgs e)
        {
            View.ShowAddProductView();
        }

        void View_AddPersonClicked(object sender, System.EventArgs e)
        {
            View.ShowAddPersonView();
        }

        void View_Load(object sender, System.EventArgs e)
        {
            
        }

        void View_CloseFormClicked(object sender, System.EventArgs e)
        {
            View.Exit();
        }
    }
}
