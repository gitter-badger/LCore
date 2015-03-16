using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCL.Startup))]
namespace MVCL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
