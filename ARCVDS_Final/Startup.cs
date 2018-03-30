using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARCVDS_Final.Startup))]
namespace ARCVDS_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
