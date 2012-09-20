using System;
using WinFormsMvp;
using WinFormsMvp.UnitTests.Views;

namespace WinFormsMvp.UnitTests.Presenters
{
    public class CreateProjectPresenter : Presenter<ICreateProjectView>
    {
        public CreateProjectPresenter(ICreateProjectView view)
            :base(view)
        {

        }
    }
}
