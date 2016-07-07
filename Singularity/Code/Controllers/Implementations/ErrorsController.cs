using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class ErrorsController : ManageController<Models.Error>
        {
        public override string PageGroup => ControllerHelper.Menu_Admin;
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
