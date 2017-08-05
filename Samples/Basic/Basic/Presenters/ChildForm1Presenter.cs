using Basic.Views;
using WinFormsMvp;

namespace Basic.Presenters
{
    public class ChildForm1Presenter : Presenter<IChildForm1View>
    {
        public ChildForm1Presenter(IChildForm1View view) 
            : base(view)
        {
            View.Load += View_Load;
        }

        private void View_Load(object sender, System.EventArgs e)
        {
            View.SetMessageOnView("This ChildForm1 has loaded!");
        }
    }
}
