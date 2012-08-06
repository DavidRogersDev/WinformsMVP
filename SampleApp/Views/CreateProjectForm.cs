using System;
using System.Windows.Forms;
using SampleApp.Models;
using WinFormsMvp.Forms;

namespace SampleApp.Views
{
    public class CreateProjectForm : MvpForm<CreateProjectModel>, ICreateProjectView
    {
        private TextBox NameTextBox;
        private TextBox DescriptionTextBox;
        private Label NameLabel;
        private Label DescriptionLabel;
        private CheckBox VisibilityCheckBox;
        private Button CreateProjectButton;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.InitializeComponent();
        }

        #region Implementation of ICreateProjectView

        public event EventHandler AddProjectClicked;

        #endregion

        private void InitializeComponent()
        {
            this.CreateProjectButton = new Button();
            this.NameTextBox = new TextBox();
            this.DescriptionTextBox = new TextBox();
            this.NameLabel = new Label();
            this.DescriptionLabel = new Label();
            this.VisibilityCheckBox = new CheckBox();
            this.SuspendLayout();


            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(75, 48);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.MaxLength = 100;
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(75, 73);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.MaxLength = 250;
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 52);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(10, 77);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 5;
            this.DescriptionLabel.Text = "Description:";
            // 
            // VisibilityCheckBox
            // 
            this.VisibilityCheckBox.AutoSize = true;
            this.VisibilityCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VisibilityCheckBox.Location = new System.Drawing.Point(25, 102);
            this.VisibilityCheckBox.Name = "VisibilityCheckBox";
            this.VisibilityCheckBox.Size = new System.Drawing.Size(65, 17);
            this.VisibilityCheckBox.TabIndex = 7;
            this.VisibilityCheckBox.Text = "Visibility:";
            this.VisibilityCheckBox.UseVisualStyleBackColor = true;

            // 
            // CreateProjectButton
            // 
            this.CreateProjectButton.Location = new System.Drawing.Point(75, 126);
            this.CreateProjectButton.Name = "AddProjectButton";
            this.CreateProjectButton.Size = new System.Drawing.Size(100, 23);
            this.CreateProjectButton.TabIndex = 8;
            this.CreateProjectButton.Text = "Add Project";
            this.CreateProjectButton.UseVisualStyleBackColor = true;
            this.CreateProjectButton.Click += new EventHandler(CreateProjectButton_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 328);
            this.Controls.Add(this.VisibilityCheckBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(CreateProjectButton);
            this.Name = "CreateProjectForm";
            this.Text = "Add a New Project";

            this.ResumeLayout(false);
            this.PerformLayout();


        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            Model.Name = NameTextBox.Text.Trim();
            Model.Description = DescriptionTextBox.Text.Trim();
            Model.Visibilty = VisibilityCheckBox.Checked;
            
            AddProjectClicked(null, EventArgs.Empty);
        }
    }
}
