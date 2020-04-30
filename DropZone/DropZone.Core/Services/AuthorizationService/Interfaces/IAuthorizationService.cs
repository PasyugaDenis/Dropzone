using DropZone.Core.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace DropZone.Core.Services.AuthorizationService
{
    public interface IAuthorizationService
    {
        string GetUserToken(UserModel user);

        UserModel GetUserModel(IEnumerable<Claim> claims);
    }
}
