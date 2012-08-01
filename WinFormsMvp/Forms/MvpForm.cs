using System.ComponentModel;
using System.Windows.Forms;
using WinFormsMvp.Binder;

namespace WinFormsMvp.Forms
{
    public class MvpForm<TModel> : Form, IView<TModel>
        where TModel : class
    {
        private TModel model;
        private readonly PresenterBinder presenterBinder = new PresenterBinder();


        public MvpForm()
        {
            presenterBinder.PerformBinding(this);
        }

        #region Implementation of IView<TModel>

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TModel Model
        {
            get { return model; }
            set { model = value; }
        }

        #endregion

        #region Implementation of IView

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { return false; } // todo: need to consider the use of this in this new environment!!!
        }

        #endregion
    }
}
