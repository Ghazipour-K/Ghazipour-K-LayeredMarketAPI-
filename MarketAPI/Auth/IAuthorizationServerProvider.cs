using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Market
{
    public interface IAuthorizationServerProvider
    {
        Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context);
        Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context);

    }
}