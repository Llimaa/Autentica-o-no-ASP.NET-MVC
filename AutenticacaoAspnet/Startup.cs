using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AutenticacaoAspnet.Startup))]

namespace AutenticacaoAspnet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Autenticacao/Login")
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}

