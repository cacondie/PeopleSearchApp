using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class DomainClassesTests
    {
        [TestMethod]
        public void Address_ToString()
        {
            Address sut = new Address();
            sut.Street1 = "123 Main";
            sut.City = "Objectville";
            sut.State = "New York";
            sut.PostalCode = "12345";

            string expected = "123 Main, Objectville, New York 12345";

            Assert.AreEqual(expected, sut.ToString());
        }
        [TestMethod]
        public void Interest_ToString()
        {
            Interest sut = new Interest();
            sut.PersonId = 1;
            sut.InterestName = "Football";

            string expected = "ID: 1; Interest: Football";

            Assert.AreEqual(expected, sut.ToString());
        }
        [TestMethod]
        public void Person_Age()
        {
            Person sut = new Person();
            sut.Id = 7;
            sut.BirthDate = new DateTime(1980, 5, 12);

            int expected = (int)Math.Floor(((DateTime.Now - sut.BirthDate).TotalDays / 365.25));

            Assert.AreEqual(expected, sut.Age);
        }
        [TestMethod]
        public void Person_ToString()
        {
            Person sut = new Person();
            sut.Id = 7;
            sut.FirstName = "John";
            sut.LastName = "Doe";
            sut.SSN = "131-02-9874";

            string expected = "ID:7, Name: John Doe, SSN: 131-02-9874";

            Assert.AreEqual(expected, sut.ToString());
        }
        [TestMethod]
        public void Person_FullName()
        {
            Person sut = new Person();
            sut.FirstName = "Jane";
            sut.LastName = "Smith";

            string expected = "Jane Smith";

            Assert.AreEqual(expected, sut.FullName);
        }
    }
}
