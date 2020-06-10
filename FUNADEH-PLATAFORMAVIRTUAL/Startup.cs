using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FUNADEH_PLATAFORMAVIRTUAL.Startup))]
namespace FUNADEH_PLATAFORMAVIRTUAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
