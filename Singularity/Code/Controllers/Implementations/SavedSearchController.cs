using Singularity.Models;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class SavedSearchController : ManageController<SavedSearch>
        {
        public override string PageGroup => ControllerHelper.Menu_Admin;
        public SavedSearchController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
