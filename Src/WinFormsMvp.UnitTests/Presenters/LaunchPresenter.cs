using System;
using WinFormsMvp.UnitTests.Views;

namespace WinFormsMvp.UnitTests.Presenters
{
   public class LaunchPresenter : Presenter<ILaunchView>
    {
       public LaunchPresenter(ILaunchView view): base(view)
       {
           View.CloseFormClicked += View_CloseFormClicked;
           View.Load += view_Load;
       }

       void view_Load(object sender, EventArgs e)
       {
           throw new NotImplementedException();
       }

       void View_CloseFormClicked(object sender, EventArgs e)
       {
           throw new NotImplementedException();
       }
    }
}
