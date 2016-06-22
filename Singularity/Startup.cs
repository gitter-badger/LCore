using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Singularity.Config.Startup))]
namespace Singularity.Config
    {
    public partial class Startup
        {
        public void Configuration(IAppBuilder app)
            {
            this.ConfigureAuth(app);
            }
        }
    }
