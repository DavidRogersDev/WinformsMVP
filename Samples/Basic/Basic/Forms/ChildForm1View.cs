using System;
using Basic.Views;
using WinFormsMvp.Forms;

namespace Basic.Forms
{
    public partial class ChildForm1View : MvpForm, IChildForm1View 
    {
        public ChildForm1View()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void SetMessageOnView(string message)
        {
            lblMessage.Text = message.Trim();
        }
    }
}
