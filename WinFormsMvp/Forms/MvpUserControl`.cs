using System.Windows.Forms;
using WinFormsMvp.Binder;

namespace WinFormsMvp.Forms
{
    public partial class MvpUserControl : UserControl, IView
    {
        private readonly PresenterBinder presenterBinder = new PresenterBinder();
        public MvpUserControl()
        {
            presenterBinder.PerformBinding(this);
            ThrowExceptionIfNoPresenterBound = true;
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
    }
}
