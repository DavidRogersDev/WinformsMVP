using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsMvp.Forms;

namespace LicenceTracker.Views
{
    public partial class AddProductView : MvpForm, IAddProductView
    {
        public AddProductView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SoftwareTypesComboBox.DataSource = new BindingSource(SoftwareTypes, null);
        }

        public event EventHandler CloseFormClicked;

        public event EventHandler AddProductClicked;



        private void AddProductButton_Click(object sender, EventArgs e)
        {            
            Description = DescriptionTextBox.Text.Trim();            
            Name = NameTextBox.Text.Trim();
            TypeId = (int)SoftwareTypesComboBox.SelectedValue;
            

            AddProductClicked(this, EventArgs.Empty);
        }


        public void Exit()
        {
            Close();
        }





        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> SoftwareTypes { get; set; }
        public int TypeId { get; set; }



        
    }
}
