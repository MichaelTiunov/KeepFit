using System.Web.Http;

namespace KeepFit.Web.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Hello!";
        }
    }
}
