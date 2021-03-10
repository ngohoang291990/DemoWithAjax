using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoWithAjax.Startup))]
namespace DemoWithAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
