using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace ExampleApplication.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllAsQueryable();
        IEnumerable<T> GetAll();
        T Single(Func<T, bool> predicate);
        T First(Func<T, bool> predicate);
        IEnumerable<T> Find(Func<T, bool> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        void Add(T entity);
        void Add(string entitySetName, T entity);
        void Delete(T entity);
        void Delete(Func<T, bool> predicate);
        void Attach(T entity);
        int SaveChanges();
        int SaveChanges(SaveOptions options);
    }
}
