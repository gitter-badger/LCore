using System.Web.Mvc;

namespace LMVC.Controllers
    {
    [Authorize]
    public class ErrorController : Controller
        {

        public ActionResult Index()
            {
            // ReSharper disable once Mvc.ViewNotResolved
            return this.View();
            }
        }
    }
