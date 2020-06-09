using DropZone.API;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(AuthConfig))]

namespace DropZone.API
{
    public class AuthConfig
    {
        public static OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions
        {
            AllowInsecureHttp = true,
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1)
        };

        public void Configuration(IAppBuilder app)
        {
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuth(app);
        }

        public void OAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}