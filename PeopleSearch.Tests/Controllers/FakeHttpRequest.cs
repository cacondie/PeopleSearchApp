using System.Collections.Specialized;
using System.Web;

namespace PeopleSearch.Tests.Controllers
{
    internal class FakeHttpRequest : HttpRequestBase
    {
        public override string this[string key]
        {
            get { return null; }
        }
        public override NameValueCollection Headers
        {
            get { return new NameValueCollection(); }
        }
    }
}