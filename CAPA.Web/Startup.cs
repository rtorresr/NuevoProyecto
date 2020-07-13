using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CAPA.Web.Startup))]
namespace CAPA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
