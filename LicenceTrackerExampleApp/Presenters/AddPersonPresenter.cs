using LicenceTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMvp;

namespace LicenceTracker.Presenters
{
    public class AddPersonPresenter : Presenter<IAddPersonView>
    {
        public AddPersonPresenter(IAddPersonView view)
            :base(view)
        {
            View.CloseFormClicked += View_CloseFormClicked;
            View.AddPersonClicked += View_AddPersonClicked;
        }

        void View_AddPersonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            View.Exit();
        }
    }
}
