using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Owin;
using System;
using System.Web.Http;
using Market.Service;
using Market.Repository;

[assembly: OwinStartup(typeof(Market.Startup))]
namespace Market
{
    public class Startup
    {
        //private readonly IAuthorizationServerProvider _authorizationServerProvider = null;

        //public Startup(IAuthorizationServerProvider authorizationServerProvider)
        //{
        //    _authorizationServerProvider = authorizationServerProvider;
        //}

        public void Configuration(IAppBuilder app)
        {
            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //MyAuthorizationServerProvider class will validate the user credentials
                //Provider = (IOAuthAuthorizationServerProvider)_authorizationServerProvider

                Provider = new AuthorizationServerProvider(new Admin(new AdminRepository(new MarketEntities())))
            };

            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}