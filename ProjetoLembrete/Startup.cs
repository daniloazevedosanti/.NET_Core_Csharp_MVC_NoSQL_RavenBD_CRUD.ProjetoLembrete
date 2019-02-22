using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoLembrete.Startup))]
namespace ProjetoLembrete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
