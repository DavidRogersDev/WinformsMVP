using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface ITestItView : IView
    {
            event EventHandler CloseMe;
            TestItModel Model { get; set; }

            void Close();
    }
}
