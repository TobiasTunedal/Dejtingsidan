using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dejtingsida.Startup))]
namespace Dejtingsida
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
