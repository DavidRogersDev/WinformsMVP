using Basic.Models;
using Basic.Views;
using WinFormsMvp;

namespace Basic.Presenters
{
    public class ChildForm2Presenter : Presenter<IChildForm2View>
    {
        public ChildForm2Presenter(IChildForm2View view) 
            : base(view)
        {
            View.Load += View_Load;
        }

        private void View_Load(object sender, System.EventArgs e)
        {
            View.Model = new PersonViewModel {FirstName = "Lorenzo", LastName = "Lamas"};
        }
    }
}
