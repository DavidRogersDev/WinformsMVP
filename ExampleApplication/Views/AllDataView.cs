using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExampleApplication.Custom;
using ExampleApplication.Models;
using ExampleApplication.Presenters;
using WinFormsMvp.Forms;
using WinFormsMvp;
using System.Drawing;

namespace ExampleApplication.Views
{
    [PresenterBinding(typeof(ManageAllDataPresenter))]
    public class AllDataView : MvpForm<ViewAllWorkModel> , IAllDataView
    {
        #region Controls

        private DataGridView ProjectsDataGridView;
        private DataGridView TasksDataGridView;
        private DataGridView WorkItemsDataGridView;
        private DataGridViewTextBoxColumn ProjectNameColumn;
        private DataGridViewTextBoxColumn ProjectDescriptionColumn;
        private DataGridViewCheckBoxColumn ProjectVisibleColumn;
        private DataGridViewLinkColumn ProjectDeleteColumn;
        private Label ProjectsLabel;
        private DataGridViewTextBoxColumn TaskNameColumn;
        private DataGridViewTextBoxColumn TaskDescriptionColumn;
        private DataGridViewCheckBoxColumn TaskVisibleColumn;
        private DataGridViewLinkColumn TaskDeleteColumn;
        private Label TasksLabel;
        private DataGridViewTextBoxColumn WorkItemDescriptionColumn;
        private DataGridViewTextBoxColumn WorkItemDurationColumn;
        private DataGridViewTextBoxColumn WorkItemDateColumn;
        private DataGridViewLinkColumn WorkItemDeleteColumn;
        private Label WorkItemsLabel;

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.InitializeComponent();

            this.ProjectsDataGridView.DataSource = Model.Projects;
        }

        private void InitializeComponent()
        {
            this.ProjectsDataGridView = new DataGridView();
            this.TasksDataGridView = new DataGridView();
            this.WorkItemsDataGridView = new DataGridView();
            this.TaskNameColumn = new DataGridViewTextBoxColumn();
            this.TaskDescriptionColumn = new DataGridViewTextBoxColumn();
            this.TaskVisibleColumn = new DataGridViewCheckBoxColumn();
            this.TaskDeleteColumn = new DataGridViewLinkColumn();
            this.TasksLabel = new Label();
            this.ProjectNameColumn = new DataGridViewTextBoxColumn();
            this.ProjectDescriptionColumn = new DataGridViewTextBoxColumn();
            this.ProjectVisibleColumn = new DataGridViewCheckBoxColumn();
            this.ProjectDeleteColumn = new DataGridViewLinkColumn();
            this.ProjectsLabel = new Label();
            this.WorkItemDescriptionColumn = new DataGridViewTextBoxColumn();
            this.WorkItemDurationColumn = new DataGridViewTextBoxColumn();
            this.WorkItemDateColumn = new DataGridViewTextBoxColumn();
            this.WorkItemDeleteColumn = new DataGridViewLinkColumn();
            this.WorkItemsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkItemsDataGridView)).BeginInit();

            // 
            // ProjectsLabel
            // 
            this.ProjectsLabel.AutoSize = true;
            this.ProjectsLabel.Location = new System.Drawing.Point(36, 20);
            this.ProjectsLabel.Name = "ProjectsLabel";
            this.ProjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsLabel.Size = new System.Drawing.Size(35, 13);
            this.ProjectsLabel.TabIndex = 3;
            this.ProjectsLabel.Text = "Projects:";

            // 
            // TasksLabel
            // 
            this.TasksLabel.AutoSize = true;
            this.TasksLabel.Location = new System.Drawing.Point(36, 200);
            this.TasksLabel.Name = "TasksLabel";
            this.TasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TasksLabel.Size = new System.Drawing.Size(35, 13);
            this.TasksLabel.TabIndex = 3;
            this.TasksLabel.Text = "Tasks:";

            // 
            // WorkItemsLabel
            // 
            this.WorkItemsLabel.AutoSize = true;
            this.WorkItemsLabel.Location = new System.Drawing.Point(36, 390);
            this.WorkItemsLabel.Name = "WorkItemsLabel";
            this.WorkItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkItemsLabel.Size = new System.Drawing.Size(35, 13);
            this.WorkItemsLabel.TabIndex = 3;
            this.WorkItemsLabel.Text = "Work Items:";

            // 
            // ProjectsDataGridView
            // 
            this.ProjectsDataGridView.AutoGenerateColumns = false;
            this.ProjectsDataGridView.AllowUserToAddRows = false;
            this.ProjectsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjectsDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.ProjectNameColumn,
            this.ProjectDescriptionColumn,
            this.ProjectVisibleColumn,
            this.ProjectDeleteColumn});
            this.ProjectsDataGridView.Location = new System.Drawing.Point(36, 40);
            this.ProjectsDataGridView.Name = "ProjectsDataGridView";
            this.ProjectsDataGridView.ReadOnly = false;
            this.ProjectsDataGridView.Size = new System.Drawing.Size(844, 150);
            this.ProjectsDataGridView.TabIndex = 0;
            this.ProjectsDataGridView.CellClick += new DataGridViewCellEventHandler(ProjectsDataGridView_CellClick);
            this.ProjectsDataGridView.CellContentClick += new DataGridViewCellEventHandler(ProjectsDataGridView_CellContentClick);
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AutoGenerateColumns = false;
            this.TasksDataGridView.AllowUserToAddRows = false;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.TaskNameColumn,
            this.TaskDescriptionColumn,
            this.TaskVisibleColumn,
            this.TaskDeleteColumn});
            this.TasksDataGridView.Location = new System.Drawing.Point(36, 225);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.ReadOnly = true;
            this.TasksDataGridView.Size = new System.Drawing.Size(844, 150);
            this.TasksDataGridView.TabIndex = 1;
            this.TasksDataGridView.CellClick += new DataGridViewCellEventHandler(TasksDataGridView_CellClick);
            this.TasksDataGridView.CellContentClick += new DataGridViewCellEventHandler(TasksDataGridView_CellContentClick);

            // 
            // WorkItemsDataGridView
            // 
            this.WorkItemsDataGridView.AutoGenerateColumns = false;
            this.WorkItemsDataGridView.AllowUserToAddRows = false;
            this.WorkItemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkItemsDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.WorkItemDescriptionColumn,
            this.WorkItemDurationColumn,
            this.WorkItemDateColumn,
            this.WorkItemDeleteColumn});
            this.WorkItemsDataGridView.Location = new System.Drawing.Point(36, 420);
            this.WorkItemsDataGridView.Name = "WorkItemsDataGridView";
            this.WorkItemsDataGridView.ReadOnly = true;
            this.WorkItemsDataGridView.Size = new System.Drawing.Size(844, 150);
            this.WorkItemsDataGridView.TabIndex = 2;
            this.WorkItemsDataGridView.CellContentClick += new DataGridViewCellEventHandler(WorkItemsDataGridView_CellContentClick);

            // 
            // TaskNameColumn
            // 
            this.TaskNameColumn.DataPropertyName = "Name";
            this.TaskNameColumn.HeaderText = "Task Name";
            this.TaskNameColumn.Name = "TaskNameColumn";
            this.TaskNameColumn.ReadOnly = true;
            this.TaskNameColumn.Width = 300;
            // 
            // TaskDescriptionColumn
            // 
            this.TaskDescriptionColumn.DataPropertyName = "Description";
            this.TaskDescriptionColumn.HeaderText = "Description";
            this.TaskDescriptionColumn.Name = "TaskDescriptionColumn";
            this.TaskDescriptionColumn.ReadOnly = true;
            this.TaskDescriptionColumn.Width = 300;
            // 
            // TaskVisibleColumn
            // 
            this.TaskVisibleColumn.DataPropertyName = "Visible";
            this.TaskVisibleColumn.HeaderText = "Visible";
            this.TaskVisibleColumn.Name = "TaskVisibleColumn";
            this.TaskVisibleColumn.ReadOnly = false;
            this.TaskVisibleColumn.Width = 50;
            // 
            // TaskDeleteColumn
            // 
            this.TaskDeleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.TaskDeleteColumn.HeaderText = "Delete";
            this.TaskDeleteColumn.Name = "TaskDeleteColumn";
            this.TaskDeleteColumn.ReadOnly = true;

            this.TaskDeleteColumn.HeaderText = "Delete Task";
            this.TaskDeleteColumn.UseColumnTextForLinkValue = true;
            this.TaskDeleteColumn.Text = "Delete";
            this.TaskDeleteColumn.ActiveLinkColor = Color.White;
            this.TaskDeleteColumn.LinkBehavior = LinkBehavior.SystemDefault;
            this.TaskDeleteColumn.LinkColor = Color.DarkSeaGreen;
            this.TaskDeleteColumn.TrackVisitedState = true;
            this.TaskDeleteColumn.VisitedLinkColor = Color.YellowGreen;
            // 
            // ProjectNameColumn
            // 
            this.ProjectNameColumn.DataPropertyName = "Name";
            this.ProjectNameColumn.HeaderText = "Project Name";
            this.ProjectNameColumn.Name = "ProjectNameColumn";
            this.ProjectNameColumn.ReadOnly = true;
            this.ProjectNameColumn.Width = 300;
            // 
            // ProjectDescriptionColumn
            // 
            this.ProjectDescriptionColumn.DataPropertyName = "Description";
            this.ProjectDescriptionColumn.HeaderText = "Description";
            this.ProjectDescriptionColumn.Name = "ProjectDescriptionColumn";
            this.ProjectDescriptionColumn.ReadOnly = true;
            this.ProjectDescriptionColumn.Width = 300;
            // 
            // ProjectVisibleColumn
            // 
            this.ProjectVisibleColumn.DataPropertyName = "Visible";
            this.ProjectVisibleColumn.HeaderText = "Visible";
            this.ProjectVisibleColumn.Name = "ProjectVisibleColumn";
            this.ProjectVisibleColumn.ReadOnly = false;
            this.ProjectVisibleColumn.Width = 50;
            // 
            // ProjectDeleteColumn
            // 
            this.ProjectDeleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ProjectDeleteColumn.HeaderText = "Delete";
            this.ProjectDeleteColumn.Name = "ProjectDeleteColumn";
            this.ProjectDeleteColumn.ReadOnly = true;
            this.ProjectDeleteColumn.HeaderText = "Delete Project";
            this.ProjectDeleteColumn.UseColumnTextForLinkValue = true;
            this.ProjectDeleteColumn.Text = "Delete";
            this.ProjectDeleteColumn.ActiveLinkColor = Color.White;
            this.ProjectDeleteColumn.LinkBehavior = LinkBehavior.SystemDefault;
            this.ProjectDeleteColumn.LinkColor = Color.DarkSeaGreen;
            this.ProjectDeleteColumn.TrackVisitedState = true;
            this.ProjectDeleteColumn.VisitedLinkColor = Color.YellowGreen;
            // 
            // WorkItemDescriptionColumn
            // 
            this.WorkItemDescriptionColumn.DataPropertyName = "Description";
            this.WorkItemDescriptionColumn.HeaderText = "Work Item Description";
            this.WorkItemDescriptionColumn.Name = "WorkItemDescriptionColumn";
            this.WorkItemDescriptionColumn.ReadOnly = true;
            this.WorkItemDescriptionColumn.Width = 300;
            // 
            // WorkItemDurationColumn
            // 
            this.WorkItemDurationColumn.DataPropertyName = "Duration";
            this.WorkItemDurationColumn.HeaderText = "Duration";
            this.WorkItemDurationColumn.Name = "WorkItemDurationColumn";
            this.WorkItemDurationColumn.ReadOnly = true;
            this.WorkItemDurationColumn.Width = 150;
            // 
            // WorkItemDateColumn
            // 
            this.WorkItemDateColumn.DataPropertyName = "DateOfWork";
            this.WorkItemDateColumn.HeaderText = "Date Performed";
            this.WorkItemDateColumn.Name = "WorkItemDateColumn";
            this.WorkItemDateColumn.ReadOnly = true;
            this.WorkItemDateColumn.Width = 150;
            // 
            // WorkItemDeleteColumn
            // 
            this.WorkItemDeleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.WorkItemDeleteColumn.HeaderText = "Delete";
            this.WorkItemDeleteColumn.Name = "WorkItemDeleteColumn";
            this.WorkItemDeleteColumn.ReadOnly = true;
            this.WorkItemDeleteColumn.HeaderText = "Delete Task";
            this.WorkItemDeleteColumn.UseColumnTextForLinkValue = true;
            this.WorkItemDeleteColumn.Text = "Delete";
            this.WorkItemDeleteColumn.ActiveLinkColor = Color.White;
            this.WorkItemDeleteColumn.LinkBehavior = LinkBehavior.SystemDefault;
            this.WorkItemDeleteColumn.LinkColor = Color.DarkSeaGreen;
            this.WorkItemDeleteColumn.TrackVisitedState = true;
            this.WorkItemDeleteColumn.VisitedLinkColor = Color.YellowGreen;

            // 
            // AllDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 600);
            this.Controls.Add(this.WorkItemsDataGridView);
            this.Controls.Add(this.TasksDataGridView);
            this.Controls.Add(this.ProjectsDataGridView);
            this.Controls.Add(this.ProjectsLabel);
            this.Controls.Add(this.TasksLabel);
            this.Controls.Add(this.WorkItemsLabel);
            this.Name = "AllDataView";
            this.Text = "AllDataView";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.ProjectsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkItemsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        void WorkItemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < WorkItemsDataGridView.Rows.Count)
            {
                var selectedWorkItem = WorkItemsDataGridView.Rows[e.RowIndex].DataBoundItem as Work;
                SelectedWorkItemEventArgs workItemEventArgs = new SelectedWorkItemEventArgs(selectedWorkItem);

                if (WorkItemsDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewLinkCell))
                {
                    WorkItemDeleteSelected(this, workItemEventArgs);
                }
            }
        }

        void TasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < ProjectsDataGridView.Rows.Count)
            {
                Model.SelectedTask = TasksDataGridView.Rows[e.RowIndex].DataBoundItem as Task;

                if (TasksDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewCheckBoxCell))
                {
                    Model.SelectedTask.Visible =
                        !(bool)
                         (TasksDataGridView.Rows[e.RowIndex].Cells["TaskVisibleColumn"] as DataGridViewCheckBoxCell).
                             Value;
                    TaskVisibilityToggled(null, EventArgs.Empty);
                }
                else if (TasksDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewLinkCell))
                {
                    TaskDeleteSelected(null, EventArgs.Empty);
                }

                TaskHasBeenSelected(null, EventArgs.Empty);
            }
        }

        private void ProjectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProjectsDataGridView.CurrentCell.OwningColumn.CellType == typeof (DataGridViewCheckBoxCell))
            {
                Model.SelectedProject.Visible =
                    !(bool)
                     (ProjectsDataGridView.Rows[e.RowIndex].Cells["ProjectVisibleColumn"] as DataGridViewCheckBoxCell).
                         Value;
                ProjectVisibilityToggled(null, EventArgs.Empty);
            }
            else if (ProjectsDataGridView.CurrentCell.OwningColumn.CellType == typeof (DataGridViewLinkCell))
            {
                ProjectDeleteSelected(null, EventArgs.Empty);
            }
         
            ProjectHasBeenSelected(null, EventArgs.Empty);
        }



        private void TasksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < ProjectsDataGridView.Rows.Count)
            {
                Model.SelectedTask = TasksDataGridView.Rows[e.RowIndex].DataBoundItem as Task;

                if (TasksDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewCheckBoxCell))
                {
                    Model.SelectedTask.Visible =
                        !(bool)
                         (TasksDataGridView.Rows[e.RowIndex].Cells["TaskVisibleColumn"] as DataGridViewCheckBoxCell).
                             Value;
                    TaskVisibilityToggled(null, EventArgs.Empty);
                }
                else if (TasksDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewLinkCell))
                {
                    TaskDeleteSelected(null, EventArgs.Empty);
                }

                TaskHasBeenSelected(null, EventArgs.Empty);
            }
        }

        private void ProjectsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < ProjectsDataGridView.Rows.Count)
            {
                Model.SelectedProject = ProjectsDataGridView.Rows[e.RowIndex].DataBoundItem as Project;

                if (ProjectsDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewCheckBoxCell))
                {
                    Model.SelectedProject.Visible = !(bool)(ProjectsDataGridView.Rows[e.RowIndex].Cells["ProjectVisibleColumn"]).Value;
                    ProjectVisibilityToggled(null, EventArgs.Empty);
                }
                else if (ProjectsDataGridView.CurrentCell.OwningColumn.CellType == typeof(DataGridViewLinkCell))
                {
                    ProjectDeleteSelected(null, EventArgs.Empty);
                }

                ProjectHasBeenSelected(null, EventArgs.Empty);
            }
        }


        #region Implementation of IAllDataView

        public event EventHandler ProjectDeleteSelected;
        public event EventHandler ProjectHasBeenSelected;
        public event EventHandler ProjectVisibilityToggled;
        public event EventHandler TaskHasBeenSelected;
        public event EventHandler TaskDeleteSelected;
        public event EventHandler TaskVisibilityToggled;
        public event EventHandler<SelectedWorkItemEventArgs> WorkItemDeleteSelected;

        public void PopulateProjects(IList<Project> projects)
        {
            this.ProjectsDataGridView.DataSource = projects;
        }

        public void PopulateTasksByProjectId(IList<Task> tasksOfSelectedProject)
        {
            this.WorkItemsDataGridView.DataSource = null;
            this.TasksDataGridView.DataSource = tasksOfSelectedProject;
        }

        public void PopulateWorkItemsByTaskId(IList<Work> workItemsOfSelectedProject)
        {
            this.WorkItemsDataGridView.DataSource = workItemsOfSelectedProject;
        }

        #endregion
    }
}
