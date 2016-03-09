using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Singularity.Config.RazorGeneratorMvcStart), "Start")]

namespace Singularity.Config
    {
    public static class RazorGeneratorMvcStart
        {
        public static void Start()
            {
            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
            {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages. x
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
            }
        }
    }