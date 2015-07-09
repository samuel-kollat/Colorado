using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Colorado.Startup))]
namespace Colorado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
