using System;
using WinFormsMvp;

namespace Basic.Views
{
    public interface ICoreView : IView
    {
        event EventHandler ViewLoading;
    }
}
