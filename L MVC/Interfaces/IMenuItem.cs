
using System.Web.Mvc;

namespace LMVC.Controllers
    {
    public interface IMenuItem
        {
        MvcHtmlString Icon { get; set; }

        string PageGroup { get; set; }
        string MenuText { get; set; }

        string Action { get; set; }
        string ControllerName { get; set; }

        int? TotalCount { get; set; }
        }
    public class MenuItem : IMenuItem
        {
        public MvcHtmlString Icon { get; set; }
        public string PageGroup { get; set; }
        public string MenuText { get; set; }

        public string Action { get; set; }
        public string ControllerName { get; set; }

        public int? TotalCount { get; set; }
        }
    }