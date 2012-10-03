using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExampleApplication.Ioc;
using ExampleApplication.Views;
using StructureMap;

namespace ExampleApplication
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
