using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using ExampleApplication.Views;
using WinFormsMvp;

namespace ExampleApplication.Presenters
{
    public class TestItPresenter : Presenter<ITestItView>
    {
        public TestItPresenter(ITestItView view) : base(view)
        {
            View.Load += new EventHandler(View_Load);
            View.CloseMe += new EventHandler(View_CloseMe);
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Model = new TestItModel(); 
        }

        void View_CloseMe(object sender, EventArgs e)
        {

            View.Close();
        }
    }
}
