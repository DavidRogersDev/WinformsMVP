using System;
using System.Windows.Forms;
using SimpleInjector.Diagnostics;
using SimpleInjector.Forms;
using SimpleInjector.Services;
using SimpleInjector.Views;
using WinFormsMvp.Binder;
using WinFormsMvp.SimpleInjector;

namespace SimpleInjector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new Container();
            PresenterBinder.Factory = new SimpleInjectorPresenterFactory(container);
            ConfigureIoc(container);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());

            container.Dispose();
        }

        private static void ConfigureIoc(Container container)
        {
            container.Register<IPeopleManagerService, PeopleManagerService>(Lifestyle.Transient);

            Registration registration = container.GetRegistration(typeof(IPeopleManagerService)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Presenters will call Dispose on these services.");

            container.Verify();
        }
    }
}
