using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ExampleApplication.Models;
using WinFormsMvp.Forms;

namespace ExampleApplication.Views
{
    public class CreateTaskForm : MvpForm<CreateTaskModel>, ICreateTaskView
    {
        #region Private Variables

        private Button CloseButton;
        private Button CreateTaskButton;
        private TextBox DescriptionTextBox;
        private Label DescriptionLabel;
        private Label EstimateLabel;
        private TextBox EstimateTextBox;
        private Label NameLabel;
        private TextBox NameTextBox;
        private ProjectChooserControl projectChooserControl;
        private PictureBox SuccessPictureBox;
        private CheckBox VisibilityCheckBox;

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.CloseButton = new Button();
            this.CreateTaskButton = new Button();
            this.EstimateLabel = new Label();
            this.EstimateTextBox = new TextBox();
            this.NameTextBox = new TextBox();
            this.DescriptionTextBox = new TextBox();
            this.DescriptionLabel = new Label();
            this.NameLabel = new Label();
            this.VisibilityCheckBox = new CheckBox();
            this.SuccessPictureBox = new PictureBox();
            this.projectChooserControl = new ProjectChooserControl();
            this.SuspendLayout();

            this.SuccessPictureBox.Image = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tick.png"), true);
            this.SuccessPictureBox.Location = new Point(75, 200);
            this.SuccessPictureBox.Visible = false;

            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(75, 48);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.MaxLength = 150;
            this.NameTextBox.Size = new System.Drawing.Size(480, 20);
            this.NameTextBox.TabIndex = 1;

            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(450, 126);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new EventHandler(CloseButton_Click);

            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(75, 73);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.MaxLength = 250;
            this.DescriptionTextBox.Size = new System.Drawing.Size(480, 20);
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
            //this.ProjectLabel.AutoSize = true;
            //this.ProjectLabel.Location = new System.Drawing.Point(10, 22);
            //this.ProjectLabel.Name = "ProjectLabel";
            //this.ProjectLabel.Size = new System.Drawing.Size(38, 13);
            //this.ProjectLabel.TabIndex = 4;
            //this.ProjectLabel.Text = "Project:";

            // 
            // VisibilityCheckBox
            // 
            this.VisibilityCheckBox.AutoSize = true;
            this.VisibilityCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VisibilityCheckBox.Location = new System.Drawing.Point(75, 130);
            this.VisibilityCheckBox.Name = "VisibilityCheckBox";
            this.VisibilityCheckBox.Size = new System.Drawing.Size(65, 17);
            this.VisibilityCheckBox.TabIndex = 7;
            this.VisibilityCheckBox.Text = "Visibility";
            this.VisibilityCheckBox.UseVisualStyleBackColor = true;

            // 
            // EstimateTextBox
            // 
            this.EstimateTextBox.Location = new System.Drawing.Point(75, 102);
            this.EstimateTextBox.Name = "EstimateTextBox";
            this.EstimateTextBox.MaxLength = 80;
            this.EstimateTextBox.Size = new System.Drawing.Size(80, 20);
            this.EstimateTextBox.TabIndex = 2;

            // 
            // EstimateLabel
            // 
            this.EstimateLabel.AutoSize = true;
            this.EstimateLabel.Location = new System.Drawing.Point(10, 102);
            this.EstimateLabel.Name = "EstimateLabel";
            this.EstimateLabel.Size = new System.Drawing.Size(100, 13);
            this.EstimateLabel.TabIndex = 4;
            this.EstimateLabel.Text = "Estimate:";

            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.Location = new System.Drawing.Point(75, 160);
            this.CreateTaskButton.Name = "AddTaskButton";
            this.CreateTaskButton.Size = new System.Drawing.Size(100, 23);
            this.CreateTaskButton.TabIndex = 8;
            this.CreateTaskButton.Text = "Add Task";
            this.CreateTaskButton.UseVisualStyleBackColor = true;
            this.CreateTaskButton.Click += new EventHandler(CreateTaskButton_Click);

            // 
            // ProjectChooserControl
            // 
            this.projectChooserControl.Location = new Point(10, 18);
            this.projectChooserControl.Name = "bla";
            this.projectChooserControl.Size = new Size(490,30);

            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 226);
            this.Controls.Add(this.VisibilityCheckBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.EstimateLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.EstimateTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.CreateTaskButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SuccessPictureBox);
            this.Controls.Add(this.projectChooserControl);
            this.Name = "CreateTaskForm";
            this.Text = "Add a New Task";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreateTaskButton_Click(object sender, EventArgs e)
        {
            Model.SelectedProject = projectChooserControl.SelectedProject;
            Model.Name = NameTextBox.Text.Trim();
            Model.Description = DescriptionTextBox.Text.Trim();
            Model.Visibilty = VisibilityCheckBox.Checked;
            Model.Estimate = decimal.Parse(EstimateTextBox.Text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);

            AddTaskClicked(null, EventArgs.Empty);
            SuccessPictureBox.Visible = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            projectChooserControl.Exit();
            CloseFormClicked(null, EventArgs.Empty);
        }

        #region Implementation of ICreateTaskView

        public event EventHandler AddTaskClicked;
        public event EventHandler CloseFormClicked;

        public void CloseForm()
        {
            Close();
        }

        #endregion
    }
}
