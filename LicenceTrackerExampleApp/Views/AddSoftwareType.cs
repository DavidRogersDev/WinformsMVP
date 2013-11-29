using LicenceTracker.Models;
using System;
using System.Windows.Forms;
using WinFormsMvp.Forms;

namespace LicenceTracker.Views
{
    public partial class AddSoftwareType : MvpForm, IAddSoftwareTypeView
    {
        public AddSoftwareType()
        {
            InitializeComponent();
        }

        public event EventHandler AddProductClicked;
        public event EventHandler CloseFormClicked;
        public AddSoftwareTypeModel Model { get; set; }


        public void Exit()
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newSoftwareType = Model.NewSoftwareType;
            newSoftwareType.Name = NameTextBox.Text.Trim();
            newSoftwareType.Description = DescriptionTextBox.Text.Trim();

            AddProductClicked(this, EventArgs.Empty);

            MessageBox.Show("The new Software Type has been added successfully.");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseFormClicked(this, EventArgs.Empty);
        }

    }
}
