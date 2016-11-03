using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleSearch.DataLayer;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class SeedDataTests
    {
        [TestMethod]
        public void TestSeedFile()
        {
            string jsondata = File.ReadAllText("SeedData.json");
            IEnumerable<SeedPerson> seed = JsonConvert.DeserializeObject<IEnumerable<SeedPerson>>(jsondata);

            Assert.IsTrue(seed.Count() > 500);
        }
    
    }




    internal class SeedAddress
    {
        public string Street1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    internal class SeedPerson
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
