using System.Web.Mvc;

namespace LMVC.Controllers
    {
    public class TestController : Controller
        {
        public ActionResult JavascriptTest()
            {
            // ReSharper disable once Mvc.ViewNotResolved
            return this.View();
            }

        public ActionResult SingularityTest()
            {
            // ReSharper disable once Mvc.ViewNotResolved
            return this.View();
            }
        }
    }
