using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VentaAutos.Startup))]
namespace VentaAutos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
