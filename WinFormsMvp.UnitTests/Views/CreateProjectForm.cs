using System;
using System.IO;
using System.Windows.Forms;
using WinFormsMvp.Forms;
using WinFormsMvp.UnitTests.Models;

namespace WinFormsMvp.UnitTests.Views
{
    public class CreateProjectForm : MvpForm<CreateProjectModel>, ICreateProjectView
    {

        #region Implementation of ICreateProjectView

        public event EventHandler AddProjectClicked;
        public event EventHandler CloseFormClicked;

        public void CloseForm()
        {
            this.Close();
        }

        #endregion

    }
}
