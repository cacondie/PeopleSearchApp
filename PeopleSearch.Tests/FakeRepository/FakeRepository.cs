using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace PeopleSearch.Tests.FakeRepository
{
    internal class FakePersonRepository : IRepository<Person>
    {

        List<Person> inMemoryList;
        private string[] possibleIntrests = new[] { "Video Games", "Hiking", "3d Animation", "Movies","Utah Jazz", "Skiing" };
        private string[] possibleFirstNames = new[] { "Jim", "Sally", "Craig", "John", "Henry", "Tracie", "Blake", "Nathan", "Ryan", "Natalie", "Skyler", "Chad" };
        private string[] possibleLastNames = new[] { "Smith", "Jones", "Anderson", "Thompson", "Simpson", "Wood", "Baggins", "Asher", "Bell", "Johnson", "Allen", "Benson" };

        public FakePersonRepository()
        {
            inMemoryList = PopulateList();
        }
        private List<Person> PopulateList()
        {
            Random random = new Random();
            
            List<Person> tempList = new List<Person>(100);
            for (int i = 0; i < tempList.Capacity; i++)
            {
                Person tempPerson = CreateTempPerson(random);
                tempList.Add(tempPerson);
            }

            return tempList;
        }

        private Person CreateTempPerson(Random random)
        {
            var tempPerson = new Person();
            tempPerson.FirstName = possibleFirstNames[random.Next(possibleFirstNames.Length)];
            tempPerson.LastName = possibleLastNames[random.Next(possibleLastNames.Length)];
            tempPerson.SSN = string.Format("{0}-{1}-{2}",random.Next(100,999), random.Next(10, 99), random.Next(1000, 9999));

            tempPerson.Interests.Add(new Interest { InterestName = possibleIntrests[random.Next(possibleIntrests.Length)] });
            tempPerson.Interests.Add(new Interest { InterestName = possibleIntrests[random.Next(possibleIntrests.Length)] });
            tempPerson.Interests.Add(new Interest { InterestName = possibleIntrests[random.Next(possibleIntrests.Length)] });
            tempPerson.BirthDate = new DateTime(1950, 1, 1).AddDays(random.Next(10000));
            return tempPerson;
        }

        public void Add(Person newEntity)
        {
            inMemoryList.Add(newEntity);
        }

        public void AddRange(IEnumerable<Person> entities)
        {
            inMemoryList.AddRange(entities);
        }

        public IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate)
        {
            Func<Person, bool> pred = predicate.Compile();
            return inMemoryList.Where(pred);
        }

        public IEnumerable<Person> FindAll()
        {
            return inMemoryList;
        }

        public Person FindById(int id)
        {
            return inMemoryList.Where(p => p.Id == id).Single();
        }

        public void Remove(Person entity)
        {
            inMemoryList.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Person> entities)
        {
            foreach (Person entity in entities)
            {
                inMemoryList.Remove(entity);
            }
            
        }
    }
}
