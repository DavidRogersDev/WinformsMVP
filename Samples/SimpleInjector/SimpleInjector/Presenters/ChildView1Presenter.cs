using System;
using SimpleInjector.Services;
using SimpleInjector.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace SimpleInjector.Presenters
{
    public class ChildView1Presenter : Presenter<IChildView1>, IDisposable
    {
        private readonly IPeopleManagerService _peopleManagerService;
        private bool _disposed;

        public ChildView1Presenter(IChildView1 view, IPeopleManagerService peopleManagerService) 
            : base(view)
        {
            _peopleManagerService = peopleManagerService;
            View.Load += View_Load;
            View.FormClosing += View_FormClosing;
        }

        private void View_FormClosing(object sender, EventArgs e)
        {
            PresenterBinder.Factory.Release(this); // release from Ioc. i.e. SimpleInjector in this case. 
        }

        private void View_Load(object sender, EventArgs e)
        {
            var peeps = _peopleManagerService.GetPeople();
            View.People = peeps;
        }

        public void Dispose()
        {
           CleanUp(true);
        }
        public void CleanUp(bool disposing)
        {
            if(disposing && !_disposed)
            {
                ((IDisposable) _peopleManagerService).Dispose();
                _disposed = true;
            }
        }
    }
}
