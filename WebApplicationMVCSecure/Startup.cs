using Microsoft.Owin;
using Owin;
using WebApplicationMVCSecure.Database;

[assembly: OwinStartupAttribute(typeof(WebApplicationMVCSecure.Startup))]
namespace WebApplicationMVCSecure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SQLFullDB initDB = new SQLFullDB(DataConnectionResource.LOCALMSSQLSERVER);
            ConfigureAuth(app);
        }
    }
}
