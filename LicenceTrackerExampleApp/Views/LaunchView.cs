using LicenceTracker.Models;
using System;
using WinFormsMvp.Forms;

namespace LicenceTracker.Views
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
            Close();
        }
        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            CloseFormClicked(this, EventArgs.Empty);
        }
    }
}
