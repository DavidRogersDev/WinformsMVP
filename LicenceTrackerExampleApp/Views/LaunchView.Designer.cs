namespace LicenceTracker.Views
{
    partial class LaunchView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddLicenceButton = new System.Windows.Forms.Button();
            this.AddPersonButton = new System.Windows.Forms.Button();
            this.AddSoftwareTypeButton = new System.Windows.Forms.Button();
            this.LogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstLiveLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(163, 209);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddLicenceButton
            // 
            this.AddLicenceButton.Image = global::LicenceTracker.Properties.Resources.software_48;
            this.AddLicenceButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddLicenceButton.Location = new System.Drawing.Point(41, 147);
            this.AddLicenceButton.Name = "AddLicenceButton";
            this.AddLicenceButton.Size = new System.Drawing.Size(80, 85);
            this.AddLicenceButton.TabIndex = 2;
            this.AddLicenceButton.Text = "Add Software";
            this.AddLicenceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddLicenceButton.UseVisualStyleBackColor = true;
            this.AddLicenceButton.Click += new System.EventHandler(this.AddLicenceButton_Click);
            // 
            // AddPersonButton
            // 
            this.AddPersonButton.Image = global::LicenceTracker.Properties.Resources.msewtz_Business_Person;
            this.AddPersonButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddPersonButton.Location = new System.Drawing.Point(41, 26);
            this.AddPersonButton.Name = "AddPersonButton";
            this.AddPersonButton.Size = new System.Drawing.Size(80, 85);
            this.AddPersonButton.TabIndex = 1;
            this.AddPersonButton.Text = "Add Person";
            this.AddPersonButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddPersonButton.UseVisualStyleBackColor = true;
            this.AddPersonButton.Click += new System.EventHandler(this.AddPersonButton_Click);
            // 
            // AddSoftwareTypeButton
            // 
            this.AddSoftwareTypeButton.Image = global::LicenceTracker.Properties.Resources.softwareType_48;
            this.AddSoftwareTypeButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddSoftwareTypeButton.Location = new System.Drawing.Point(158, 26);
            this.AddSoftwareTypeButton.Name = "AddSoftwareTypeButton";
            this.AddSoftwareTypeButton.Size = new System.Drawing.Size(80, 85);
            this.AddSoftwareTypeButton.TabIndex = 3;
            this.AddSoftwareTypeButton.Text = "Add Software Type";
            this.AddSoftwareTypeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddSoftwareTypeButton.UseVisualStyleBackColor = true;
            this.AddSoftwareTypeButton.Click += new System.EventHandler(this.AddSoftwareTypeButton_Click);
            // 
            // lstLiveLog
            // 
            this.lstLiveLog.FormattingEnabled = true;
            this.lstLiveLog.Location = new System.Drawing.Point(41, 258);
            this.lstLiveLog.Name = "lstLiveLog";
            this.lstLiveLog.Size = new System.Drawing.Size(197, 43);
            this.lstLiveLog.TabIndex = 4;
            // 
            // LaunchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 313);
            this.Controls.Add(this.lstLiveLog);
            this.Controls.Add(this.AddSoftwareTypeButton);
            this.Controls.Add(this.AddLicenceButton);
            this.Controls.Add(this.AddPersonButton);
            this.Controls.Add(this.ExitButton);
            this.Name = "LaunchView";
            this.Text = "Admin Screen";
            ((System.ComponentModel.ISupportInitialize)(this.LogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddPersonButton;
        private System.Windows.Forms.Button AddLicenceButton;
        private System.Windows.Forms.Button AddSoftwareTypeButton;
        private System.Windows.Forms.BindingSource LogBindingSource;
        private System.Windows.Forms.ListBox lstLiveLog;
    }
}