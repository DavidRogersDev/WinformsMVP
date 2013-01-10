using System;
using System.Windows.Forms;
using ExampleApplication.Models;
using ExampleApplication.Presenters;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    [PresenterBinding(typeof(MainEntryMenuPresenter))]
    public class MainView : WinFormsMvp.Forms.MvpForm<MainFormModel>, IMainView
    {
        Button ViewAllDataButton;
        Button EnterWorkItemButton;
        Button CreateTaskButton;
        Button CreateProjectButton;
        LinkLabel ExitLinkLabel;

        public MainView()
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ViewAllDataButton = new Button();
            this.EnterWorkItemButton = new Button();
            this.CreateTaskButton = new Button();
            this.CreateProjectButton = new Button();
            this.ExitLinkLabel = new LinkLabel();
            this.SuspendLayout();
            // 
            // ViewAllDataButton
            // 
            this.ViewAllDataButton.Location = new System.Drawing.Point(142, 126);
            this.ViewAllDataButton.Name = "AllDataViewButton";
            this.ViewAllDataButton.Size = new System.Drawing.Size(61, 52);
            this.ViewAllDataButton.TabIndex = 0;
            this.ViewAllDataButton.Text = "View All Data";
            this.ViewAllDataButton.UseVisualStyleBackColor = true;
            this.ViewAllDataButton.Click += new EventHandler(ViewAllDataButton_Click);
            // 
            // EnterWorkItemButton
            // 
            this.EnterWorkItemButton.Location = new System.Drawing.Point(60, 126);
            this.EnterWorkItemButton.Name = "CreateWorkItemButton";
            this.EnterWorkItemButton.Size = new System.Drawing.Size(61, 52);
            this.EnterWorkItemButton.TabIndex = 1;
            this.EnterWorkItemButton.Text = "Enter Work Details";
            this.EnterWorkItemButton.UseVisualStyleBackColor = true;
            this.EnterWorkItemButton.Click += new EventHandler(EnterWorkItemButton_Click);
            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.Location = new System.Drawing.Point(142, 38);
            this.CreateTaskButton.Name = "CreateTaskButton";
            this.CreateTaskButton.Size = new System.Drawing.Size(61, 52);
            this.CreateTaskButton.TabIndex = 2;
            this.CreateTaskButton.Text = "Create Task";
            this.CreateTaskButton.UseVisualStyleBackColor = true;
            this.CreateTaskButton.Click += new EventHandler(CreateTaskButton_Click);
            // 
            // CreateProjectButton
            // 
            this.CreateProjectButton.Location = new System.Drawing.Point(60, 38);
            this.CreateProjectButton.Name = "CreateProjectButton";
            this.CreateProjectButton.Size = new System.Drawing.Size(61, 52);
            this.CreateProjectButton.TabIndex = 3;
            this.CreateProjectButton.Text = "Create Project";
            this.CreateProjectButton.UseVisualStyleBackColor = true;
            this.CreateProjectButton.Click += new EventHandler(CreateProjectButton_Click);
            // 
            // ExitLinkLabel
            // 
            this.ExitLinkLabel.AutoSize = true;
            this.ExitLinkLabel.Location = new System.Drawing.Point(227, 194);
            this.ExitLinkLabel.Name = "ExitLinkLabel";
            this.ExitLinkLabel.Size = new System.Drawing.Size(24, 13);
            this.ExitLinkLabel.TabIndex = 4;
            this.ExitLinkLabel.TabStop = true;
            this.ExitLinkLabel.Text = "Exit";
            this.ExitLinkLabel.Click += new EventHandler(ExitLinkLabel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 216);
            this.Controls.Add(this.CreateProjectButton);
            this.Controls.Add(this.CreateTaskButton);
            this.Controls.Add(this.EnterWorkItemButton);
            this.Controls.Add(this.ViewAllDataButton);
            this.Controls.Add(this.ExitLinkLabel);
            this.Name = "MainForm";
            this.Text = "WinFormsMvp - Sample App";

            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }

        void ExitLinkLabel_Click(object sender, EventArgs e)
        {
            CloseFormClicked(null, EventArgs.Empty);
        }

        void ViewAllDataButton_Click(object sender, EventArgs e)
        {
            Model.FormToDisplay = typeof(AllDataView);
            DisplayCreateProjectView(null, EventArgs.Empty);
        }

        void EnterWorkItemButton_Click(object sender, EventArgs e)
        {
            Model.FormToDisplay = typeof (CreateWorkItemForm);
            DisplayCreateProjectView(null, EventArgs.Empty);
        }

        void CreateTaskButton_Click(object sender, EventArgs e)
        {
            Model.FormToDisplay = typeof (CreateTaskForm);
            DisplayCreateProjectView(null, EventArgs.Empty);
        }

        void CreateProjectButton_Click(object sender, EventArgs e)
        {
            Model.FormToDisplay = typeof(CreateProjectForm);
            DisplayCreateProjectView(null, EventArgs.Empty);
        }


        #region Implementation of IMainView

        public event EventHandler CloseFormClicked;
        public event EventHandler DisplayCreateProjectView;

        public void DisplayView()
        {
            Type typeOfFormToLoad = Model.FormToDisplay;
            (Activator.CreateInstance(typeOfFormToLoad) as Form).ShowDialog();
        }

        public void Exit()
        {
            this.Close();
        }

        #endregion
    }
}
