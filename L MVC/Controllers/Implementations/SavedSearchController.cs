using LMVC.Models;
using System.Web.Mvc;
using LMVC.Account;

namespace LMVC.Controllers
    {
    [Authorize]
    public class SavedSearchController : ManageController<SavedSearch>
        {
        public override string PageGroup => SingularityControllerHelper.Menu_Admin;

        public SavedSearchController(IAuthenticationService Auth) : base(Auth) { }
        public SavedSearchController() { }
        }
    }
