using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoVD.Startup))]
namespace ProyectoVD
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
