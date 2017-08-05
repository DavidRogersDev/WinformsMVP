using System;
using WinFormsMvp.UnitTests.Models;
using WinFormsMvp.UnitTests.Presenters;

namespace WinFormsMvp.UnitTests.Views
{
    [PresenterBinding(typeof(MainEntryMenuPresenter))]
    public class MainView : WinFormsMvp.Forms.MvpForm<MainFormModel>, IMainView
    {
        public MainView()
        {

        }

        public event EventHandler CloseFormClicked;

        public event EventHandler DisplayCreateProjectView;

        public void DisplayView()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
