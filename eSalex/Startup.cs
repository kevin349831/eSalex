using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eSalex.Startup))]
namespace eSalex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
