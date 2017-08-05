
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SimpleInjector.Views;
using WinFormsMvp;

namespace SimpleInjector.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {
        public MainPresenter(IMainView view)
            : base(view)
        {
            View.Load += View_Load;
            View.LoadChildForm1 += View_LoadChildForm1;
        }

        private void View_LoadChildForm1(object sender, EventArgs e)
        {
            Type peopleForm = GetViewTypeFromInterface(typeof(IChildView1));
            View.LoadChildForm(peopleForm);
        }

        private void View_Load(object sender, EventArgs e)
        {
            
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
