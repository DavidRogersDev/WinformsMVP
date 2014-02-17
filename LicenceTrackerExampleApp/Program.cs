using LicenceTracker.Db;
using LicenceTracker.Services;
using LicenceTracker.Views;
using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace LicenceTracker
{
    static class Program
    {
        private static IUnityContainer _unityContainer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", @"../../App_Data");
            Database.SetInitializer(new LicenceTrackerInitializer());
            var db = new LicenceTrackerContext();
            db.People.Find(1);

            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<ISoftwareService, SoftwareService>(new TransientLifetimeManager());
            PresenterBinder.Factory = new UnityPresenterFactory(_unityContainer);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaunchView());

        }
    }
}
