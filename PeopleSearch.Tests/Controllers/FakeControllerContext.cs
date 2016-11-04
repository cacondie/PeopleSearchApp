using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Tests.Controllers
{
    internal class FakeControllerContext:ControllerContext
    {
        HttpContextBase _context = new FakeHttpContext();

        public override HttpContextBase HttpContext
        {
            get { return _context; }
            set { _context = value; }
        }
    }
}
