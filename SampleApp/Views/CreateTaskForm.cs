using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SampleApp.ExampleData;
using SampleApp.Models;
using WinFormsMvp.Forms;

namespace SampleApp.Views
{
    public class CreateTaskForm : MvpForm<CreateTaskModel>, ICreateTaskView
    {
        private TextBox NameTextBox;
        private TextBox DescriptionTextBox;
        private Label DescriptionLabel;
        private Label NameLabel;
        private Label ProjectLabel;
        private CheckBox VisibilityCheckBox;
        private Button CreateTaskButton;
        private ComboBox ProjectsComboBox;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.InitializeComponent();

            this.ProjectsComboBox.DataSource = Model.Projects;
            this.ProjectsComboBox.DisplayMember = "Name";
        }

        private void InitializeComponent()
        {
            this.CreateTaskButton = new Button();
            this.NameTextBox = new TextBox();
            this.DescriptionTextBox = new TextBox();
            this.DescriptionLabel = new Label();
            this.NameLabel = new Label();
            this.ProjectLabel = new Label();
            this.VisibilityCheckBox = new CheckBox();
            this.ProjectsComboBox = new ComboBox();
            this.SuspendLayout();

            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(75, 48);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.MaxLength = 150;
            this.NameTextBox.Size = new System.Drawing.Size(300, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(75, 73);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.MaxLength = 250;
            this.DescriptionTextBox.Size = new System.Drawing.Size(300, 20);
            this.DescriptionTextBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 52);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(100, 13);
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
            // ProjectLabel
            // 
            this.ProjectLabel.AutoSize = true;
            this.ProjectLabel.Location = new System.Drawing.Point(10, 22);
            this.ProjectLabel.Name = "ProjectLabel";
            this.ProjectLabel.Size = new System.Drawing.Size(38, 13);
            this.ProjectLabel.TabIndex = 4;
            this.ProjectLabel.Text = "Project:";

            // 
            // VisibilityCheckBox
            // 
            this.VisibilityCheckBox.AutoSize = true;
            this.VisibilityCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VisibilityCheckBox.Location = new System.Drawing.Point(75, 102);
            this.VisibilityCheckBox.Name = "VisibilityCheckBox";
            this.VisibilityCheckBox.Size = new System.Drawing.Size(65, 17);
            this.VisibilityCheckBox.TabIndex = 7;
            this.VisibilityCheckBox.Text = "Visibility:";
            this.VisibilityCheckBox.UseVisualStyleBackColor = true;

            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.Location = new System.Drawing.Point(75, 130);
            this.CreateTaskButton.Name = "AddTaskButton";
            this.CreateTaskButton.Size = new System.Drawing.Size(100, 23);
            this.CreateTaskButton.TabIndex = 8;
            this.CreateTaskButton.Text = "Add Task";
            this.CreateTaskButton.UseVisualStyleBackColor = true;
            this.CreateTaskButton.Click += new EventHandler(CreateTaskButton_Click);

            // 
            // ProjectsComboBox
            // 
            this.ProjectsComboBox.FormattingEnabled = true;
            this.ProjectsComboBox.Location = new System.Drawing.Point(75, 18);
            this.ProjectsComboBox.Name = "ProjectsComboBox";
            this.ProjectsComboBox.Size = new System.Drawing.Size(250, 21);
            this.ProjectsComboBox.TabIndex = 9;
            this.ProjectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 328);
            this.Controls.Add(this.VisibilityCheckBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ProjectLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ProjectsComboBox);
            this.Controls.Add(this.CreateTaskButton);
            this.Name = "CreateTaskForm";
            this.Text = "Add a New Task";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreateTaskButton_Click(object sender, EventArgs e)
        {
            Model.SelectedProject = this.ProjectsComboBox.SelectedItem as Project;
            Model.Name = NameTextBox.Text.Trim();
            Model.Description = DescriptionTextBox.Text.Trim();
            Model.Visibilty = VisibilityCheckBox.Checked;

            AddTaskClicked(null, EventArgs.Empty);
        }

        #region Implementation of ICreateTaskView

        public event EventHandler AddTaskClicked;

        #endregion
    }
}
