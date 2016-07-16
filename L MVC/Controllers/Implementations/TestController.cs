using System.Web.Mvc;

namespace Singularity.Controllers
    {
    public class TestController : Controller
        {
        public ActionResult JavascriptTest()
            {
            return this.View();
            }

        public ActionResult SingularityTest()
            {
            return this.View();
            }
        }
    }
