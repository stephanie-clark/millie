using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Millie.Web.Startup))]
namespace Millie.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
