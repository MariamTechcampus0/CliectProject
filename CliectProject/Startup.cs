using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CliectProject.Startup))]
namespace CliectProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
