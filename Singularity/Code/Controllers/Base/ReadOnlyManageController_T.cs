using Singularity.Account;
using Singularity.Models;

namespace Singularity.Controllers
    {
    public abstract class ReadOnlyManageController<T> : ManageController<T>
        where T : class, IModel
        {
        public override ModelPermissions OverridePermissions => new ModelPermissions
            {
            View = true,
            ViewInactive = true,
            Export = true
            };

        protected ReadOnlyManageController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
