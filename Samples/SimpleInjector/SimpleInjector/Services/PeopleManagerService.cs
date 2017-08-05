using System;
using System.Collections.Generic;

namespace SimpleInjector.Services
{
    public class PeopleManagerService : IPeopleManagerService, IDisposable
    {
        private bool _disposed;

        public IEnumerable<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { FirstName = "Lorenzo", LastName = "Lamas"},
                new Person { FirstName = "Bobby", LastName = "Sixkiller"},
                new Person { FirstName = "Dutch", LastName = "Dixon"}
            };
        }

        public void Dispose()
        {
            CleanUp(true);
        }

        public void CleanUp(bool disposing)
        {
            if (disposing && !_disposed)
            {
                // lets pretend this class has stuff to dispose of. Probably a db connection
                _disposed = true;
            }
        }
    }
}
