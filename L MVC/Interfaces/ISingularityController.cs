using LCore.Tools;
using Singularity.Account;

namespace Singularity.Controllers
    {
    public interface ISingularityController
        {
        IAuthenticationService Auth { get; set; }

        Set<string, string>[] Breadcrumbs { get; }
        string DefaultLayout { get; }
        }
    }