using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheEvents.Startup))]
namespace TheEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
