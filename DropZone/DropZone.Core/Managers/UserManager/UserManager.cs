using DropZone.Core.Models;
using DropZone.Core.Services.UserService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(
            IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserModel> GetUserAsync(long userId)
        {
            var user = await _userService.GetUserAsync(userId);

            return user;
        }

        public async Task<JumpBookModel> GetUserJumpBookAsync(long userId)
        {
            var jumpBook = await _userService.GetUserJumpBookAsync(userId);

            return jumpBook;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();

            return users;
        }

        public async Task<IEnumerable<UserModel>> GetSportsmenAsync()
        {
            var users = await _userService.GetSportsmenAsync();

            return users;
        }

        public async Task<IEnumerable<UserModel>> GetDropZoneUsersAsync(long dropZoneId)
        {
            var dropZoneUsers = await _userService.GetDropZoneUsersAsync(dropZoneId);

            return dropZoneUsers;
        }

        public async Task<UserModel> EditUserAsync(UserModel model)
        {
            var user = await _userService.EditUserAsync(model);

            return user;
        }

        public async Task DeleteUserAsync(long userId)
        {
            await _userService.DeleteUserAsync(userId);
        }

        public async Task ChangeUserRoleAsync(long userId, long roleId)
        {
            await _userService.ChangeUserRoleAsync(userId, roleId);
        }

        public async Task ChangeUserPasswordAsync(UserModel model)
        {
            await _userService.ChangeUserPasswordAsync(model);
        }
    }
}
