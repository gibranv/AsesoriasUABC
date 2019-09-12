using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsesoriasUABC.Startup))]
namespace AsesoriasUABC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
