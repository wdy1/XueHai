using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XueHai.Startup))]
namespace XueHai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
