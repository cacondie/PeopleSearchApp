using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Tests.FakeRepository
{
    class FakeUnitOfWork : IUnitOfWork
    {
        public IRepository<Person> Persons { get; private set; }

        public FakeUnitOfWork()
        {
            Committed = false;
            Persons = new FakePersonRepository();
        }

        public int Commit()
        {
            Committed = true;
            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        public bool Committed { get; private set; }
    }
}
