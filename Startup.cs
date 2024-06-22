using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HwaDualFactorAuth_Netv48.Startup))]
namespace HwaDualFactorAuth_Netv48
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
