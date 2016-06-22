using System.Web.Mvc;

namespace Singularity.Controllers
    {
    public class ExamplesController : Controller
        {
        public ActionResult Examples()
            {
            return this.View();
            }
        }
    }
