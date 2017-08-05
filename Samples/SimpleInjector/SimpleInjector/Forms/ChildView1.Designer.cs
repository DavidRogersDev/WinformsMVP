namespace SimpleInjector.Forms
{
    partial class ChildView1
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
            this.lstPeopleList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPeopleList
            // 
            this.lstPeopleList.FormattingEnabled = true;
            this.lstPeopleList.Location = new System.Drawing.Point(79, 72);
            this.lstPeopleList.Name = "lstPeopleList";
            this.lstPeopleList.Size = new System.Drawing.Size(120, 95);
            this.lstPeopleList.TabIndex = 0;
            // 
            // ChildView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstPeopleList);
            this.Name = "ChildView1";
            this.Text = "ChildView1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildView1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPeopleList;
    }
}