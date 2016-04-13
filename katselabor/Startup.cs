using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(katselabor.Startup))]
namespace katselabor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
