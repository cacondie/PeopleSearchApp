using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataLayer
{
    public class EntityContext : DbContext
    {
        
        public DbSet<Person> Persons { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        
    }
}
