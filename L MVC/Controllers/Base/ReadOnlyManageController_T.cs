using LMVC.Account;
using LMVC.Models;

namespace LMVC.Controllers
    {
    public abstract class ReadOnlyManageController<T> : ManageController<T>
        where T : class, IModel
        {
        public override IModelPermissions OverridePermissions => new ModelPermissions
            {
            View = true,
            ViewInactive = true,
            Export = true
            };

        protected ReadOnlyManageController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
