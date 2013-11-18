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
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;
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
