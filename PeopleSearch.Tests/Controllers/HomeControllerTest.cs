using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch;
using PeopleSearch.Controllers;
using PeopleSearch.Tests.FakeRepository;
using PeopleSearch.Repository;

namespace PeopleSearch.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new FakeUnitOfWork());
            controller.ControllerContext = new FakeControllerContext();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Person> model = result.Model as IEnumerable<Person>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Count() > 0);
            

        }
    }
}
