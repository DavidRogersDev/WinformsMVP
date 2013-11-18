namespace LicenceTracker.Views
{
    partial class AddProductView
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.SoftwareTypesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(212, 55);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(212, 92);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(212, 176);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(120, 23);
            this.AddProductButton.TabIndex = 4;
            this.AddProductButton.Text = "Add Software Product";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // SoftwareTypesComboBox
            // 
            this.SoftwareTypesComboBox.DisplayMember = "Value";
            this.SoftwareTypesComboBox.FormattingEnabled = true;
            this.SoftwareTypesComboBox.Location = new System.Drawing.Point(212, 132);
            this.SoftwareTypesComboBox.Name = "SoftwareTypesComboBox";
            this.SoftwareTypesComboBox.Size = new System.Drawing.Size(121, 21);
            this.SoftwareTypesComboBox.TabIndex = 5;
            this.SoftwareTypesComboBox.ValueMember = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type:";
            // 
            // AddProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SoftwareTypesComboBox);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Name = "AddProductView";
            this.Text = "Add Product Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.ComboBox SoftwareTypesComboBox;
        private System.Windows.Forms.Label label3;
    }
}