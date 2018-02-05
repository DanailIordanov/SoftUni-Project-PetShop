using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetShopApplication.Startup))]
namespace PetShopApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
