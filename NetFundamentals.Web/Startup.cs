using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetFundamentals.Web.Startup))]
namespace NetFundamentals.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
