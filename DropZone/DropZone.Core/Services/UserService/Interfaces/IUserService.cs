using DropZone.Core.Models;
using System.Threading.Tasks;

namespace DropZone.Core.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel model);

        Task<UserModel> GetUserByEmailAsync(string email);

        Task<bool> IsUserExistAsync(string email);
    }
}
