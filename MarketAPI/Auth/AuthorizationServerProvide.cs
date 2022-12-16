
using Market.Repository;
using Market.Service;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Market
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider//, IAuthorizationServerProvider   
    {
        private readonly IAdmin _adminService = null;
        public AuthorizationServerProvider(IAdmin adminService)
        {
            _adminService = adminService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _adminService.LoginAsync(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                context.Validated(identity);
            
        }
    }
}