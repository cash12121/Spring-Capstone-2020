using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WPFPresentation.Startup))]
namespace WPFPresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
