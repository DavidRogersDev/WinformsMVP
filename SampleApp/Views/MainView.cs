using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SampleApp.Models;
using SampleApp.Presenters;
using WinFormsMvp;

namespace SampleApp.Views
{
    [PresenterBinding(typeof(MainEntryMenuPresenter))]
    public class MainView : WinFormsMvp.Forms.MvpForm<MainFormModel>, IMainView
    {
        Button ViewAllDataButton;
        Button EnterWorkItemButton;
        Button CreateTaskButton;
        Button CreateProjectButton;

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
            // 
            // EnterWorkItemButton
            // 
            this.EnterWorkItemButton.Location = new System.Drawing.Point(60, 126);
            this.EnterWorkItemButton.Name = "CreateWorkItemButton";
            this.EnterWorkItemButton.Size = new System.Drawing.Size(61, 52);
            this.EnterWorkItemButton.TabIndex = 1;
            this.EnterWorkItemButton.Text = "Enter Work Details";
            this.EnterWorkItemButton.UseVisualStyleBackColor = true;
            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.Location = new System.Drawing.Point(142, 38);
            this.CreateTaskButton.Name = "CreateTaskButton";
            this.CreateTaskButton.Size = new System.Drawing.Size(61, 52);
            this.CreateTaskButton.TabIndex = 2;
            this.CreateTaskButton.Text = "Create Task";
            this.CreateTaskButton.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 216);
            this.Controls.Add(this.CreateProjectButton);
            this.Controls.Add(this.CreateTaskButton);
            this.Controls.Add(this.EnterWorkItemButton);
            this.Controls.Add(this.ViewAllDataButton);
            this.Name = "MainForm";
            this.Text = "WinFormsMvp - Sample App";
            this.ResumeLayout(false);

        }

        void CreateProjectButton_Click(object sender, EventArgs e)
        {
            Model.FormToDisplay = typeof(CreateProjectForm);
            DisplayCreateProjectView(null, EventArgs.Empty);
        }


        #region Implementation of IMainView

        public event EventHandler DisplayCreateProjectView;

        public void DisplayView()
        {
            Type typeOfFormToLoad = Model.FormToDisplay;
            (Activator.CreateInstance(typeOfFormToLoad) as Form).ShowDialog();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
