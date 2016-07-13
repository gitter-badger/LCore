using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SingularityInstance.Startup))]
namespace SingularityInstance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder App)
        {
            this.ConfigureAuth(App);
        }
    }
}
