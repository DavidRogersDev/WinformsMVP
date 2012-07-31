using System;

namespace WinFormsMvp
{
    public interface IView
    {
        bool ThrowExceptionIfNoPresenterBound { get; }

        /// <summary>
        /// Occurs at the discretion of the view. 
        /// </summary>
        event EventHandler Load;

    }
}
