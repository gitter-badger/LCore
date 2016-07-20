using System.Web.Mvc;
using LMVC.Account;

namespace LMVC.Controllers
    {
    [Authorize]
    public class ErrorsController : ManageController<Models.Error>
        {
        public override string PageGroup => SingularityControllerHelper.Menu_Admin;
        /*
        public override TimeSpan ArchiveTimeSpan
            {
            get
                {
                return null;
                }
            }
         */
        public ErrorsController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
