using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureASPProcject.Startup))]
namespace AzureASPProcject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
