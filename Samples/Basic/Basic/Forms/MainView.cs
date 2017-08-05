using System;
using System.Windows.Forms;
using Basic.Views;
using WinFormsMvp.Forms;

namespace Basic.Forms
{
    public partial class MainView : MvpForm, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            OnViewLoding();

            base.OnLoad(e);
        }

        public event EventHandler ViewLoding;
        public event EventHandler LoadChildForm1;
        public event EventHandler LoadChildForm2;

        public void ConfirmLoaded()
        {
            lblStatusMessage.Text = "Main View has loaded.";
        }

        public void LoadChildForm(Type childFormType)
        {
            var constructors = childFormType.GetConstructors();
            var destinationView = constructors[0].Invoke(new object[] { }) as Form;

            destinationView.ShowDialog();
        }

        protected virtual void OnViewLoding()
        {
            ViewLoding?.Invoke(this, EventArgs.Empty);
        }

        private void btnLoadChildForm1_Click(object sender, EventArgs e)
        {
            LoadChildForm1?.Invoke(this, EventArgs.Empty);
        }

        private void btnLoadChildForm2_Click(object sender, EventArgs e)
        {
            LoadChildForm2?.Invoke(this, EventArgs.Empty);
        }
    }
}
