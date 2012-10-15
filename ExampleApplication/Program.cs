using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;
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

            //  These 2 method calls were just for funsies. I want the database access to be to the mdf file in the ExampleData folder in this solution. Runtime determined.
            var solutionDirectoryPath = GetDirectoryOfSolution();
            var projectName = GetStartupProjectName();

            //  Override default scenario and set the "DataDirectory" variable in the ConnectionString to be that of my choosing.
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(solutionDirectoryPath, Path.Combine(projectName, "ExampleData")));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }

        private static string GetStartupProjectName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(assembly.FullName);
            return assemblyName.Name;
        }

        private static string GetDirectoryOfSolution()
        {
            //  Get a hook on the Visual Studio object so we can get a path to the sln file. 
            //  For this to work, only one Visual Studion solution can be open. Otherwise, it may get a hook on the other solution.
            DTE dte = (DTE) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            return Path.GetDirectoryName(dte.Solution.FullName);
        }

        static void RegisterDependencies()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<DependancyRegistry>());
        }
    }
}
