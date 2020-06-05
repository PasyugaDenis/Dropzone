using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel model);

        Task<UserModel> EditUserAsync(UserModel model);

        Task DeleteUserAsync(long userId);

        Task ChangeUserRoleAsync(long userId, long roleId);

        Task ChangeUserPasswordAsync(UserModel model);

        Task<UserModel> GetUserAsync(string email);

        Task<UserModel> GetUserAsync(long userId);

        Task<JumpBookModel> GetUserJumpBookAsync(long userId);

        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<IEnumerable<UserModel>> GetSportsmenAsync();

        Task<IEnumerable<UserModel>> GetDropZoneUsersAsync(long dropZoneId);

        Task<bool> IsUserExistAsync(string email);

        Task<RoleModel> GetSuperAdminRoleAsync();

        Task<RoleModel> GetAdminRoleAsync();

        Task<RoleModel> GetManagerRoleAsync();

        Task<RoleModel> GetLayerRoleAsync();

        Task<RoleModel> GetSportsmanRoleAsync();
    }
}
