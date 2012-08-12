using System;
using System.Windows.Forms;
using SampleApp.ExampleData;
using SampleApp.Models;
using WinFormsMvp.Forms;

namespace SampleApp.Views
{
    public class CreateWorkItemForm : MvpForm<CreateWorkItemModel>, ICreateWorkItemView
    {
        private Label DurationLabel;
        private Label ProjectsLabel;
        private Label TasksLabel;
        private Label DateOfWorkLabel;
        private Label DescriptionLabel;
        private ComboBox ProjectsComboBox;
        private DataGridView TasksDataGridView;
        private TextBox DescriptionTextBox;
        private DateTimePicker DateOfWorkDateTimePicker;
        private NumericUpDown DurationNumericUpDown;
        private Button AddWorkItemButton;
        private Button CancelButton;
        private DataGridViewTextBoxColumn TaskNameColumn;
        private DataGridViewTextBoxColumn TaskDescriptionColumn;
        private DataGridViewTextBoxColumn TaskEstimateColumn;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.InitializeComponent();

            this.ProjectsComboBox.DataSource = Model.Projects;
            this.ProjectsComboBox.DisplayMember = "Name";
        }

        private void InitializeComponent()
        {
            this.DurationLabel = new Label();
            this.ProjectsLabel = new Label();
            this.TasksLabel = new Label();
            this.DateOfWorkLabel = new Label();
            this.DescriptionLabel = new Label();
            this.ProjectsComboBox = new ComboBox();
            this.TasksDataGridView = new DataGridView();
            this.DescriptionTextBox = new TextBox();
            this.DateOfWorkDateTimePicker = new DateTimePicker();
            this.DurationNumericUpDown = new NumericUpDown();
            this.AddWorkItemButton = new Button();
            this.CancelButton = new Button();
            this.TaskNameColumn = new DataGridViewTextBoxColumn();
            this.TaskDescriptionColumn = new DataGridViewTextBoxColumn();
            this.TaskEstimateColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(45, 246);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(50, 13);
            this.DurationLabel.TabIndex = 0;
            this.DurationLabel.Text = "Duration:";
            // 
            // ProjectsLabel
            // 
            this.ProjectsLabel.AutoSize = true;
            this.ProjectsLabel.Location = new System.Drawing.Point(45, 47);
            this.ProjectsLabel.Name = "ProjectsLabel";
            this.ProjectsLabel.Size = new System.Drawing.Size(48, 13);
            this.ProjectsLabel.TabIndex = 1;
            this.ProjectsLabel.Text = "Projects:";
            // 
            // TasksLabel
            // 
            this.TasksLabel.AutoSize = true;
            this.TasksLabel.Location = new System.Drawing.Point(45, 82);
            this.TasksLabel.Name = "TasksLabel";
            this.TasksLabel.Size = new System.Drawing.Size(39, 13);
            this.TasksLabel.TabIndex = 2;
            this.TasksLabel.Text = "Tasks:";
            // 
            // DateOfWorkLabel
            // 
            this.DateOfWorkLabel.AutoSize = true;
            this.DateOfWorkLabel.Location = new System.Drawing.Point(45, 363);
            this.DateOfWorkLabel.Name = "DateOfWorkLabel";
            this.DateOfWorkLabel.Size = new System.Drawing.Size(74, 13);
            this.DateOfWorkLabel.TabIndex = 3;
            this.DateOfWorkLabel.Text = "Date of Work:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(45, 280);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = "Description:";
            // 
            // ProjectsComboBox
            // 
            this.ProjectsComboBox.FormattingEnabled = true;
            this.ProjectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ProjectsComboBox.Location = new System.Drawing.Point(123, 47);
            this.ProjectsComboBox.Name = "ProjectsComboBox";
            this.ProjectsComboBox.Size = new System.Drawing.Size(355, 21);
            this.ProjectsComboBox.TabIndex = 5;
            this.ProjectsComboBox.SelectedIndexChanged += new EventHandler(ProjectsComboBox_SelectedIndexChanged);
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AllowUserToAddRows = false;
            this.TasksDataGridView.AllowUserToDeleteRows = false;
            this.TasksDataGridView.AutoGenerateColumns = false;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.TaskNameColumn,
            this.TaskDescriptionColumn,
            this.TaskEstimateColumn});
            this.TasksDataGridView.Location = new System.Drawing.Point(123, 82);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.ReadOnly = true;
            this.TasksDataGridView.Size = new System.Drawing.Size(355, 150);
            this.TasksDataGridView.TabIndex = 6;
            this.TasksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 
            // TaskNameColumn
            // 
            this.TaskNameColumn.DataPropertyName = "Name";
            this.TaskNameColumn.HeaderText = "Task";
            this.TaskNameColumn.Name = "TaskNameColumn";
            this.TaskNameColumn.ReadOnly = true;
            // 
            // TaskDescriptionColumn
            // 
            this.TaskDescriptionColumn.DataPropertyName = "Description";
            this.TaskDescriptionColumn.HeaderText = "Description";
            this.TaskDescriptionColumn.Name = "TaskDescriptionColumn";
            this.TaskDescriptionColumn.ReadOnly = true;
            // 
            // TaskEstimateColumn
            // 
            this.TaskEstimateColumn.DataPropertyName = "Estimate";
            this.TaskEstimateColumn.HeaderText = "Estimate";
            this.TaskEstimateColumn.Name = "TaskEstimateColumn";
            this.TaskEstimateColumn.ReadOnly = true;

            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(123, 280);
            this.DescriptionTextBox.MaxLength = 500;
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(355, 69);
            this.DescriptionTextBox.TabIndex = 7;
            // 
            // DateOfWorkDateTimePicker
            // 
            this.DateOfWorkDateTimePicker.Format = DateTimePickerFormat.Short;
            this.DateOfWorkDateTimePicker.Location = new System.Drawing.Point(123, 363);
            this.DateOfWorkDateTimePicker.Name = "DateOfWorkDateTimePicker";
            this.DateOfWorkDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.DateOfWorkDateTimePicker.TabIndex = 8;
            // 
            // DurationNumericUpDown
            // 
            this.DurationNumericUpDown.DecimalPlaces = 2;
            this.DurationNumericUpDown.Location = new System.Drawing.Point(123, 246);
            this.DurationNumericUpDown.Name = "DurationNumericUpDown";
            this.DurationNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.DurationNumericUpDown.TabIndex = 9;
            // 
            // AddWorkItemButton
            // 
            this.AddWorkItemButton.Location = new System.Drawing.Point(296, 397);
            this.AddWorkItemButton.Name = "AddWorkItemButton";
            this.AddWorkItemButton.Size = new System.Drawing.Size(100, 23);
            this.AddWorkItemButton.TabIndex = 10;
            this.AddWorkItemButton.Text = "Add Work Item";
            this.AddWorkItemButton.UseVisualStyleBackColor = true;
            this.AddWorkItemButton.Click += new EventHandler(AddWorkItemButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(403, 397);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new EventHandler(CancelButton_Click);

            // 
            // AddWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 466);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddWorkItemButton);
            this.Controls.Add(this.DurationNumericUpDown);
            this.Controls.Add(this.DateOfWorkDateTimePicker);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TasksDataGridView);
            this.Controls.Add(this.ProjectsComboBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DateOfWorkLabel);
            this.Controls.Add(this.TasksLabel);
            this.Controls.Add(this.ProjectsLabel);
            this.Controls.Add(this.DurationLabel);
            this.Name = "AddWorkForm";
            this.Text = "Add Work Item";
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();            
        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            CloseFormClicked(null, EventArgs.Empty);
        }

        void AddWorkItemButton_Click(object sender, EventArgs e)
        {
            Model.SelectedTask  = TasksDataGridView.SelectedRows[0].DataBoundItem as Task;
            Model.Description = DescriptionTextBox.Text.Trim();
            Model.Duration = (double)DurationNumericUpDown.Value;
            Model.DateOfWork = DateOfWorkDateTimePicker.Value;

            AddWorkItemClicked(null, EventArgs.Empty);
        }

        void ProjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projectsComboBox = sender as ComboBox;

            if (projectsComboBox.SelectedIndex > -1)
            {
                Model.SelectedProject = projectsComboBox.SelectedItem as Project;
                ProjectedSelectionChanged(null, EventArgs.Empty);
                TasksDataGridView.DataSource = Model.Tasks;
            }
        }

        #region Implementation of ICreateWorkItemView

        public event EventHandler ProjectedSelectionChanged;
        public event EventHandler TaskSelectionChanged;
        public event EventHandler AddWorkItemClicked;
        public event EventHandler CloseFormClicked;
        
        public void CloseForm()
        {
            this.Close();
        }

        #endregion
    }
}
