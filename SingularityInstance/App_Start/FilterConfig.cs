using System.Web.Mvc;

namespace SingularityInstance
    {
    public class FilterConfig
        {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
            {
            Filters.Add(new HandleErrorAttribute());
            }
        }
    }
