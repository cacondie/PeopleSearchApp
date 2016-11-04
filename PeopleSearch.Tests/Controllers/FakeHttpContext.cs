using System.Web;

namespace PeopleSearch.Tests.Controllers
{
    internal class FakeHttpContext : HttpContextBase
    {
        HttpRequestBase _request = new FakeHttpRequest();
        public override HttpRequestBase Request
        {
            get { return _request; }
        }

    }
}