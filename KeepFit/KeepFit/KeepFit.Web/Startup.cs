using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeepFit.Web.Startup))]
namespace KeepFit.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
