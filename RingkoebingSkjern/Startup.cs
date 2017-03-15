using System.Diagnostics;
using Microsoft.Owin;
using Owin;
using RingkoebingSkjern.DAL;

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
