using LicenceTracker.Db;
using LicenceTracker.Views;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace LicenceTracker
{
    static class Program
    {
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaunchView());

        }
    }
}
