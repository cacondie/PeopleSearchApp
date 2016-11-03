using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;
        
        public UnitOfWork(DbContext context)
        {
            _context = context;
            Persons = new SqlRepository<Person>(_context);
        }

        public IRepository<Person> Persons { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
