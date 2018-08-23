using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Basic.Views;
using WinFormsMvp;

namespace Basic.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {
        public MainPresenter(IMainView view) 
            : base(view)
        {
            View.ViewLoading += View_ViewLoading;
            View.LoadChildForm1 += View_LoadChildForm1;
            View.LoadChildForm2 += View_LoadChildForm2;
        }

        private void View_LoadChildForm2(object sender, EventArgs e)
        {
            var type = GetViewTypeFromInterface(typeof(IChildForm2View));
            View.LoadChildForm(type);
        }

        private void View_LoadChildForm1(object sender, EventArgs e)
        {
            var type = GetViewTypeFromInterface(typeof(IChildForm1View));
            View.LoadChildForm(type);
        }

        private void View_ViewLoading(object sender, EventArgs e)
        {
            View.ConfirmLoaded();
        }

        private Type GetViewTypeFromInterface(Type type)
        {
            Type viewType = null;

            var assembly = Assembly.GetExecutingAssembly();

            foreach (var exportedType in assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(Control))))
            {
                if (type.IsAssignableFrom(exportedType))
                {
                    viewType = exportedType;
                    break;
                }
            }

            return viewType;
        }
    }
}
