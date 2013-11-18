using System.Windows.Forms;
using WinFormsMvp.Binder;

namespace WinFormsMvp.Forms
{
    public partial class MvpForm : Form, IView
    {
        private readonly PresenterBinder presenterBinder = new PresenterBinder();

        public MvpForm()
        {
            presenterBinder.PerformBinding(this);
            ThrowExceptionIfNoPresenterBound = true;
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
    }
}
