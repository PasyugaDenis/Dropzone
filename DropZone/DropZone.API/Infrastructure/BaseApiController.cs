using DropZone.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace DropZone.API.Infrastructure
{
    public class BaseApiController : ApiController
    {
        private readonly IEnumerable<Claim> _claims =
            ((ClaimsPrincipal)Thread.CurrentPrincipal).Claims;

        protected UserModel UserModel
        {
            get
            {
                var claimId = _claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();
                var claimRoleId = _claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault();
                var claimEmail = _claims.Where(c => c.Type == ClaimTypes.Email).SingleOrDefault();

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
}