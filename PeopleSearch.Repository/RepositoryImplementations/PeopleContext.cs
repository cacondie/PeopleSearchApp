using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public class PeopleContext:DbContext
    {
        public PeopleContext()
            :base("name=PeopleTest")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
