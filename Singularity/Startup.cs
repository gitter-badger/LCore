using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Singularity.Startup))]
namespace Singularity
    {
    public partial class Startup
        {
        public void Configuration(IAppBuilder app)
            {
            ConfigureAuth(app);
            }
        }
    }
