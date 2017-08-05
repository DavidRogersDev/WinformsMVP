namespace SimpleInjector.Forms
{
    partial class MainView
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
            this.btnLoadPeopleForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadPeopleForm
            // 
            this.btnLoadPeopleForm.Location = new System.Drawing.Point(53, 79);
            this.btnLoadPeopleForm.Name = "btnLoadPeopleForm";
            this.btnLoadPeopleForm.Size = new System.Drawing.Size(106, 50);
            this.btnLoadPeopleForm.TabIndex = 0;
            this.btnLoadPeopleForm.Text = "Load Child Form with People";
            this.btnLoadPeopleForm.UseVisualStyleBackColor = true;
            this.btnLoadPeopleForm.Click += new System.EventHandler(this.btnLoadPeopleForm_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 220);
            this.Controls.Add(this.btnLoadPeopleForm);
            this.Name = "MainView";
            this.Text = "Main View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPeopleForm;
    }
}