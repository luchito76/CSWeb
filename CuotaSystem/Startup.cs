using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CuotaSystem.Startup))]
namespace CuotaSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
