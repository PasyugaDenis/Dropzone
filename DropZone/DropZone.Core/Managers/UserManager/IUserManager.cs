using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.UserManager
{
    public interface IUserManager
    {
        Task<UserModel> GetUserAsync(long userId);

        Task<JumpBookModel> GetUserJumpBookAsync(long userId);

        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<IEnumerable<UserModel>> GetSportsmenAsync();

        Task<IEnumerable<UserModel>> GetDropZoneUsersAsync(long dropZoneId);

        Task<UserModel> EditUserAsync(UserModel model);

        Task DeleteUserAsync(long userId);

        Task ChangeUserRoleAsync(long userId, long roleId);

        Task ChangeUserPasswordAsync(UserModel model);
    }
}
