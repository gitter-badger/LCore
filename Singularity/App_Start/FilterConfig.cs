using System.Web.Mvc;

namespace Singularity.Config
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
        {
            Filters.Add(new HandleErrorAttribute());
        }
    }
}
