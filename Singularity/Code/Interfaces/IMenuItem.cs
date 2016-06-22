
namespace Singularity.Controllers
    {
    public interface IMenuItem
        {
        string PageGroup { get; set; }
        string MenuText { get; set; }

        string Action { get; set; }
        string ControllerName { get; set; }

        int? TotalCount { get; set; }
        }
    public class MenuItem : IMenuItem
        {
        public string PageGroup { get; set; }
        public string MenuText { get; set; }

        public string Action { get; set; }
        public string ControllerName { get; set; }

        public int? TotalCount { get; set; }
        }
    }