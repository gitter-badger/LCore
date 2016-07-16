using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class ErrorController : Controller
        {

        public ActionResult Index()
            {
            return this.View();
            }
        }
    }
