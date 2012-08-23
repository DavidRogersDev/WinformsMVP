using System;
using System.Windows.Forms;
using SampleApp.Ioc;
using SampleApp.Views;
using StructureMap;

namespace SampleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterDependencies();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
            //Application.Run(new AllDataView());
            //Application.Run(new CreateWorkItemForm());
            //Application.Run(new CreateProjectForm());
            //Application.Run(new CreateTaskForm());
        }

        static void RegisterDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<DependancyRegistry>();
            });
        }
    }
}
