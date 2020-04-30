using DropZone.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(AuthConfig))]
namespace DropZone.Web
{
    public class AuthConfig
    {
        public static OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions
        {
            AllowInsecureHttp = true,
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14)
        };

        public void Configuration(IAppBuilder app)
        {
            OAuth(app);
        }

        public void OAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(OAuthOptions);
        }
    }
}