using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RingkoebingSkjern.Startup))]
namespace RingkoebingSkjern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
