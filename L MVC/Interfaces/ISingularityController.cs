using LCore.Tools;
using LMVC.Account;

namespace LMVC.Controllers
    {
    public interface ISingularityController
        {
        IAuthenticationService Auth { get; set; }

        Set<string, string>[] Breadcrumbs { get; }
        string DefaultLayout { get; }
        }
    }