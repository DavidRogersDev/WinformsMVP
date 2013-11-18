
using System;
namespace LicenceTracker.Views
{
    public partial class AddPersonView : LicenceTrackerViewSlice , IAddPersonView
    {
        public AddPersonView()
        {
            InitializeComponent();            
        }

        private void CloseFormButton_Click(object sender, System.EventArgs e)
        {
            CloseFormClicked(this, EventArgs.Empty);
        }


        public event System.EventHandler CloseFormClicked;

        public event System.EventHandler AddPersonClicked;

        public void Exit()
        {
            Close();
        }
    }
}
