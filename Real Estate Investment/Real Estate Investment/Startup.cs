using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEstateInvestment.Startup))]
namespace RealEstateInvestment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
