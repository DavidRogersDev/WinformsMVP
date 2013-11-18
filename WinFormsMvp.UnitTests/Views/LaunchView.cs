using System;
using WinFormsMvp.Forms;

namespace WinFormsMvp.UnitTests.Views
{
    public partial class LaunchView : MvpForm, ILaunchView
    {
        public LaunchView()
        {
            InitializeComponent();
        }

        public event EventHandler CloseFormClicked;

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
