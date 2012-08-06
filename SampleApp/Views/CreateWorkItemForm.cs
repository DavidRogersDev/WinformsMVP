using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Models;
using WinFormsMvp.Forms;

namespace SampleApp.Views
{
    public class CreateWorkItemForm : MvpForm<CreateWorkItemModel>, ICreateWorkItemView
    {

        #region Implementation of ICreateWorkItemView

        public event EventHandler ProjectedSelectionChanged;
        public event EventHandler TaskSelectionChanged;
        public event EventHandler AddWorkItemClicked;

        #endregion
    }
}
