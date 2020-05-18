using DropZone.Core.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DropZone.Core.Services.AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly OAuthAuthorizationServerOptions _authOptions;

        public AuthorizationService(OAuthAuthorizationServerOptions authOptions)
        {
            _authOptions = authOptions;
        }

        public string GetUserToken(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, _authOptions.AuthenticationType);
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var token = _authOptions.AccessTokenFormat.Protect(ticket);
            return token;
        }

        public UserModel GetUserModel(IEnumerable<Claim> claims)
        {
            var claimId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();
            var claimRoleId = claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault();
            var claimEmail = claims.Where(c => c.Type == ClaimTypes.Email).SingleOrDefault();

            var userModel = new UserModel
            {
                Id = long.Parse(claimId.Value),
                RoleId = long.Parse(claimRoleId.Value),
                Email = claimEmail.Value,
            };

            return userModel;
        }
    }
}
