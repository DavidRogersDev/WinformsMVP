using System.Windows.Forms;

namespace WinFormsMvp.Forms
{
    public partial class MvpUserControl : UserControl, IView
    {
        public MvpUserControl()
        {
            InitializeComponent();
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
    }
}
