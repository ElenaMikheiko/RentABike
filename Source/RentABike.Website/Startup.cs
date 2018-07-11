using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentABike.Website.Startup))]
namespace RentABike.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
