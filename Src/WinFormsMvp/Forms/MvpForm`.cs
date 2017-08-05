using System.Windows.Forms;
using WinFormsMvp.Binder;

namespace WinFormsMvp.Forms
{
    public partial class MvpForm : Form, IView
    {
        private readonly PresenterBinder presenterBinder = new PresenterBinder();

        public MvpForm()
        {
            ThrowExceptionIfNoPresenterBound = true;

            presenterBinder.PerformBinding(this);
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
    }
}
