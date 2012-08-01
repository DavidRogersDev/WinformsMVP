using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects;

namespace ExampleData
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The context object for the database
        /// </summary>
        protected ObjectContext _entities;

        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        private IObjectSet<T> _objectSet;


        #region Constructor

        public GenericRepository(ObjectContext context)
        {
            _entities = context;
            _objectSet = context.CreateObjectSet<T>();
        } 

        #endregion

        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this._objectSet.AsEnumerable();
        }
        
        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public virtual IQueryable<T> GetAllAsQueryable()
        {
            return _objectSet;
        }

        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public virtual T Single(Func<T, bool> predicate)
        {
            return this._objectSet.SingleOrDefault<T>(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public virtual T First(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault<T>(predicate);
        }

        /// <summary>
        /// Finds a record with the specified criteria. Works nicely for simple queries.
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public virtual IEnumerable<T> Find(Func<T, bool> predicate = null)
        {
            if (!ReferenceEquals(null, predicate))
            {
                return _objectSet.Where(predicate);
            }
            return _objectSet;
        }

        /// <summary>
        /// To ensure sorting and filtering is done on the database and not in code, add parameters for predicate and orderBy i.e. if that is desired. 
        /// Pass nulls for those if you want to filter/sort in C#.
        /// </summary>
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            var query = this._objectSet.AsQueryable();

            if (ReferenceEquals(null, query))
            {
                throw new NullReferenceException();
            }

            if (!ReferenceEquals(null, predicate))
            {
                query = query.Where(predicate);
            }

            //  for eager loading.
            if (!string.IsNullOrEmpty(includeProperties))
            {
                ObjectQuery<T> queryAsObjectSet = query as ObjectQuery<T>;

                if (!ReferenceEquals(queryAsObjectSet, null))
                {

                    foreach (
                        var includeProperty in
                            includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        queryAsObjectSet = queryAsObjectSet.Include(includeProperty);
                    }

                    queryAsObjectSet = queryAsObjectSet.Include(includeProperties);


                    if (ReferenceEquals(null, orderBy))
                    {
                        return queryAsObjectSet.AsEnumerable();
                    }
                 
                    return orderBy(queryAsObjectSet).AsEnumerable();

                }

                throw new NullReferenceException("The query was not a proper ObjectQuery. As a result, the attempted cast to ObjectQuery failed and null was returned");
            }

            if (ReferenceEquals(null, orderBy))
            {
                return query.AsEnumerable();
            }

            return orderBy(query).AsEnumerable();

        }

        public virtual void Add(T entity)
        {
            if (ReferenceEquals(entity,null))
            {
                throw new ArgumentNullException("entity");
            }

            this._objectSet.AddObject(entity);
        }

        public virtual void Add(string entitySetName, T entity)
        {
            if (string.IsNullOrEmpty(entitySetName))
            {
                return;
            }

            this._entities.AddObject(entitySetName, entity);
        }

        public virtual void Delete(T entity)
        {
            if (ReferenceEquals(entity, null))
            {
                throw new ArgumentNullException("entity");
            }

            this._entities.DeleteObject(entity);
        }

        /// <summary>
        /// Deletes records matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        public virtual void Delete(Func<T, bool> predicate)
        {
            IEnumerable<T> records = this._objectSet.Where<T>(predicate);

            foreach (T record in records)
            {
                this._objectSet.DeleteObject(record);
            }
        }

        public virtual void Attach(T entity)
        {
            if (ReferenceEquals(null, entity))
            {
                throw new ArgumentNullException("entity");
            }

            this._objectSet.Attach(entity);
        }

        public virtual void SaveChanges()
        {
            this._entities.SaveChanges();
        }

        public virtual void SaveChanges(SaveOptions options)
        {
            this._entities.SaveChanges(options);
        }
    }
}