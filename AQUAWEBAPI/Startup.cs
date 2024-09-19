using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AQUAWEBAPI.Startup))]

namespace AQUAWEBAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
