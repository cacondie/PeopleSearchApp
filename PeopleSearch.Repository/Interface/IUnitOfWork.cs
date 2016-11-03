using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Person> Persons { get; }
        int Commit();
    }
}
