using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Singularity.RazorGeneratorMvcStart), "Start")]

namespace Singularity
    {
    public static class RazorGeneratorMvcStart
        {
        /// <exception cref="HttpException">The Web application is running under IIS 7 in Integrated mode.</exception>
        public static void Start()
            {
            var Engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
                {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
                };

            ViewEngines.Engines.Insert(index: 0, item: Engine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(Engine);
            }
        }
    }
