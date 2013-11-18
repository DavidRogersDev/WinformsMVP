using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using ExampleApplication.Presenters;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    
    public class TestIt : WinFormsMvp.Forms.MvpForm, ITestItView
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // TestIt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "TestIt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitializeComponent();
            
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseMe(this, EventArgs.Empty);
        }

        public event EventHandler CloseMe;
        public TestItModel Model { get; set; }
    }
}
