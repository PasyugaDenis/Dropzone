using DropZone.Core.Models;
using DropZone.Core.Models.User;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.AuthorizationManager
{
    public interface IAuthorizationManager
    {
        Task<AuthModel> AuthorizeAsync(string email, string password);

        Task<AuthModel> RegisterAsync(UserModel model);
    }
}
