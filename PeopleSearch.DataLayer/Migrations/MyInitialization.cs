using Newtonsoft.Json;
using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataLayer.Migrations
{
    public class MyInitialization:DropCreateDatabaseAlways<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            IEnumerable<SeedPerson> seed = GetSeedDataFromLocalPath();

            context.Persons.AddOrUpdate(ParseSeedData(seed));
        }
        private IEnumerable<SeedPerson> GetSeedDataFromLocalPath()
        {
            string localFile = string.Format("{0}\\PeopleSearch", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            var fi = new FileInfo(string.Format("{0}\\{1}", localFile, "SeedData.json"));
            if (fi.Exists)
            {
                string jsondata = File.ReadAllText(fi.FullName);
                fi.Delete();
                Directory.Delete(Path.GetDirectoryName(fi.FullName));
                return JsonConvert.DeserializeObject<IEnumerable<SeedPerson>>(jsondata);
            }
            throw new InvalidOperationException("Can't find the seed data");

        }
        private Person[] ParseSeedData(IEnumerable<SeedPerson> listOfPersons)
        {
            List<Person> tempListOfPersons = new List<Person>();
            foreach (SeedPerson person in listOfPersons)
            {
                Person tempPerson = new Person();
                tempPerson.FirstName = person.FirstName;
                tempPerson.LastName = person.LastName;
                tempPerson.BirthDate = DateTime.Parse(person.BirthDate);
                tempPerson.SSN = person.SSN;
                Address tempAddress = new Address()
                {
                    Street1 = person.Address.Street1,
                    City = person.Address.City,
                    State = person.Address.State,
                    PostalCode = person.Address.PostalCode,

                };
                tempPerson.Addresses.Add(tempAddress);
                //tempPerson.Address=tempAddress;
                List<Interest> list = new List<Interest>();
                foreach (var interestItem in person.Interests)
                {
                    tempPerson.Interests.Add(new Interest { InterestName = interestItem });
                }

                if (person.Picture != null)
                {
                    Picture tempPicture = new Picture();
                    tempPicture.Image = Convert.FromBase64String(person.Picture);
                    tempPerson.Pictures.Add(tempPicture);
                }
                tempListOfPersons.Add(tempPerson);
            }
            return tempListOfPersons.ToArray();
        }

        private class SeedAddress
        {
            public string Street1 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
        }

        private class SeedPerson
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public SeedAddress Address { get; set; }
            public string BirthDate { get; set; }
            public string SSN { get; set; }
            public List<string> Interests { get; set; }
            public string Picture { get; set; }
        }
    }
}
