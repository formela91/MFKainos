using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kainos_konkurs.Startup))]
namespace Kainos_konkurs
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
