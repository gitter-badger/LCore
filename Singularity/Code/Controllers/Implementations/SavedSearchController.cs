using Singularity.Models;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class SavedSearchController : ManageController<SavedSearch>
        {
        public override string PageGroup => ControllerHelper.Menu_Admin;
        }
    }
