
using System;
namespace LicenceTracker.Views
{
    public partial class AddPersonView : AddPersonViewSlice, IAddPersonView
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

        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            Model.NewPerson.FirstName = FirstNameTextBox.Text.Trim();
            Model.NewPerson.LastName = LastNameTextBox.Text.Trim();

            AddPersonClicked(this, EventArgs.Empty);
        }
    }
}
