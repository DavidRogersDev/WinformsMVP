using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsMvp;

namespace SimpleInjector.Views
{
    public interface IChildView1 : IView
    {
        event FormClosingEventHandler FormClosing;
        IEnumerable<Person> People { get; set; }
    }
}
