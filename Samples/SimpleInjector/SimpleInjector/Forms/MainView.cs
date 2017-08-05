using System;
using System.Windows.Forms;
using SimpleInjector.Views;
using WinFormsMvp.Forms;

namespace SimpleInjector.Forms
{
    public partial class MainView : MvpForm, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public event EventHandler LoadChildForm1;
        public void LoadChildForm(Type childFormType)
        {
            var constructors = childFormType.GetConstructors();
            var destinationView = constructors[0].Invoke(new object[] { }) as Form;

            destinationView.ShowDialog();
        }

        private void btnLoadPeopleForm_Click(object sender, EventArgs e)
        {
            LoadChildForm1?.Invoke(sender, EventArgs.Empty);
        }
    }
}
