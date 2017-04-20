using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRIKprooviülesanne.Startup))]
namespace eRIKprooviülesanne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
