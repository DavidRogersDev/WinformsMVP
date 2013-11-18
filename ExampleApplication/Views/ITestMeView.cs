using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface ITestMeView : IView
    {
        event EventHandler CloseMe;

        CreateProjectModel Model { get; set; }

        void Close();
    }
}
