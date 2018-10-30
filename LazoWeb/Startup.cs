using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LazoWeb.Startup))]
namespace LazoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
