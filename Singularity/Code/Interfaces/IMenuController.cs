using System.Web.Mvc;
using LCore.Naming;

namespace Singularity.Controllers
    {
    public interface IMenuController : INamed
        {
        IMenuItem[] GetMenuItems(ViewContext Context);
        }
    }