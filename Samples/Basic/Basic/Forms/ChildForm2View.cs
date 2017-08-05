using System;
using System.Windows.Forms;
using Basic.Models;
using Basic.Views;
using WinFormsMvp.Forms;

namespace Basic.Forms
{
    public partial class ChildForm2View : MvpForm<PersonViewModel>, IChildForm2View
    {
        private Label lblFirstName;
        private Label lblLastName;

        public ChildForm2View()
        {
            InitializeComponent();

            InitializeComponentCustom();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // This event is raised by the form and the Load event on the View is 
            // hooked up to its handler in the Presenter.

            lblFirstName.Text = Model.FirstName;
            lblLastName.Text = Model.LastName;
        }

        private void InitializeComponentCustom()
        {
            lblFirstName = new Label();
            lblLastName = new Label();
            SuspendLayout();

            // 
            // lblFirstName
            // 
            lblFirstName.BackColor = System.Drawing.Color.White;
            lblFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblFirstName.Location = new System.Drawing.Point(47, 100);
            lblFirstName.Name = "lblStatusMessage";
            lblFirstName.Padding = new System.Windows.Forms.Padding(5);
            lblFirstName.Size = new System.Drawing.Size(177, 39);
            lblFirstName.TabIndex = 0;

            // 
            // lblLastName
            // 
            lblLastName.BackColor = System.Drawing.Color.White;
            lblLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblLastName.Location = new System.Drawing.Point(47, 200);
            lblLastName.Name = "lblStatusMessage";
            lblLastName.Padding = new System.Windows.Forms.Padding(5);
            lblLastName.Size = new System.Drawing.Size(177, 39);
            lblLastName.TabIndex = 0;

            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            ResumeLayout(false);
        }
    }
}
