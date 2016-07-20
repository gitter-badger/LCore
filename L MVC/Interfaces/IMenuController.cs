using System.Web.Mvc;
using LCore.Naming;

namespace LMVC.Controllers
    {
    public interface IMenuController : INamed
        {
        IMenuItem[] GetMenuItems(ViewContext Context);
        }
    }