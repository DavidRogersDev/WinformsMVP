namespace Basic.Forms
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
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.btnLoadChildForm1 = new System.Windows.Forms.Button();
            this.btnLoadChildForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.BackColor = System.Drawing.Color.White;
            this.lblStatusMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusMessage.Location = new System.Drawing.Point(47, 187);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Padding = new System.Windows.Forms.Padding(5);
            this.lblStatusMessage.Size = new System.Drawing.Size(177, 39);
            this.lblStatusMessage.TabIndex = 0;
            this.lblStatusMessage.Text = "label1";
            // 
            // btnLoadChildForm1
            // 
            this.btnLoadChildForm1.Location = new System.Drawing.Point(78, 32);
            this.btnLoadChildForm1.Name = "btnLoadChildForm1";
            this.btnLoadChildForm1.Size = new System.Drawing.Size(114, 23);
            this.btnLoadChildForm1.TabIndex = 1;
            this.btnLoadChildForm1.Text = "Load Child Form 1";
            this.btnLoadChildForm1.UseVisualStyleBackColor = true;
            this.btnLoadChildForm1.Click += new System.EventHandler(this.btnLoadChildForm1_Click);
            // 
            // btnLoadChildForm2
            // 
            this.btnLoadChildForm2.Location = new System.Drawing.Point(78, 78);
            this.btnLoadChildForm2.Name = "btnLoadChildForm2";
            this.btnLoadChildForm2.Size = new System.Drawing.Size(114, 23);
            this.btnLoadChildForm2.TabIndex = 2;
            this.btnLoadChildForm2.Text = "Load Child Form 2";
            this.btnLoadChildForm2.UseVisualStyleBackColor = true;
            this.btnLoadChildForm2.Click += new System.EventHandler(this.btnLoadChildForm2_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnLoadChildForm2);
            this.Controls.Add(this.btnLoadChildForm1);
            this.Controls.Add(this.lblStatusMessage);
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button btnLoadChildForm1;
        private System.Windows.Forms.Button btnLoadChildForm2;
    }
}