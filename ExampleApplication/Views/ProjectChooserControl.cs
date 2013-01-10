using System.Windows.Forms;
using ExampleApplication.Models;
using ExampleApplication.Presenters;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    [PresenterBinding(typeof(ChooseProjectPresenter))]
    public class ProjectChooserControl : WinFormsMvp.Forms.MvpUserControl<ChooseProjectModel>, IProjectChooser
    {
        private Label ProjectsLabel;
        private ComboBox ProjectsComboBox;

        public ProjectChooserControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            this.ProjectsComboBox.DataSource = Model.Projects;
            this.ProjectsComboBox.DisplayMember = "Name";
        }

        public Project SelectedProject
        {
            get
            {
                return  ProjectsComboBox.SelectedItem as Project;
            }
        }

        private void InitializeComponent()
        {
            this.ProjectsLabel = new System.Windows.Forms.Label();
            this.ProjectsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ProjectsLabel
            // 
            this.ProjectsLabel.AutoSize = true;
            this.ProjectsLabel.Location = new System.Drawing.Point(0, 5);
            this.ProjectsLabel.Name = "ProjectsLabel";
            this.ProjectsLabel.Size = new System.Drawing.Size(48, 13);
            this.ProjectsLabel.TabIndex = 0;
            this.ProjectsLabel.Text = "Projects:";
            // 
            // ProjectsComboBox
            // 
            this.ProjectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectsComboBox.FormattingEnabled = true;
            this.ProjectsComboBox.Location = new System.Drawing.Point(65, 3);
            this.ProjectsComboBox.Name = "ProjectsComboBox";
            this.ProjectsComboBox.Size = new System.Drawing.Size(355, 21);
            this.ProjectsComboBox.TabIndex = 1;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProjectsComboBox);
            this.Controls.Add(this.ProjectsLabel);
            this.Name = "Project";
            this.Size = new System.Drawing.Size(490, 30);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
