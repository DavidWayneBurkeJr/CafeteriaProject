using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BatemanCafeteria.Startup))]
namespace BatemanCafeteria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
