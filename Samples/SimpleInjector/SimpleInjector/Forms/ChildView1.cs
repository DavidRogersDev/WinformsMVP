using System;
using System.Collections.Generic;
using SimpleInjector.Views;
using WinFormsMvp.Forms;

namespace SimpleInjector.Forms
{
    public partial class ChildView1 : MvpForm, IChildView1
    {
        public ChildView1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lstPeopleList.DataSource = People;
        }

        public IEnumerable<Person> People { get; set; }

        private void ChildView1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

        }
    }
}
