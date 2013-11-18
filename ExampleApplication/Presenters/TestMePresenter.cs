using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using ExampleApplication.Views;
using WinFormsMvp;

namespace ExampleApplication.Presenters
{
    public class TestMePresenter : Presenter<ITestMeView>
    {
        public TestMePresenter(ITestMeView view) : base(view)
        {
            View.Load += View_Loaded;
            View.CloseMe += new EventHandler(View_CloseMe);
        }

        void View_CloseMe(object sender, EventArgs e)
        {
            View.Close();
        }

        public void View_Loaded(object sender, EventArgs e)
        {
            View.Model = new CreateProjectModel {Description = "Hi Dave"};
        }
    }
}
