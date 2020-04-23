using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharp_Net_module3_2_1_lab_MVCcl.Startup))]
namespace CSharp_Net_module3_2_1_lab_MVCcl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
