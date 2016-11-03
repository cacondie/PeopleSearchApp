using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _context;

        public SqlRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Single(o => o.Id == id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
