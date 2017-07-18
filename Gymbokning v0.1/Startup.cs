using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gymbokning_v0._1.Startup))]
namespace Gymbokning_v0._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
