using DropZone.Core.Models;
using DropZone.Core.Models.User;
using DropZone.Core.Services.AuthorizationService;
using DropZone.Core.Services.UserService;
using DropZone.Core.Utillities;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.AuthorizationManager
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;

        public AuthorizationManager(
            IAuthorizationService authorizationService,
            IUserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        public async Task<AuthModel> AuthorizeAsync(string email, string password)
        {
            var result = new AuthModel();

            var user = await _userService.GetUserAsync(email);

            if (user != null)
            {
                var isVerifiedPassword = Hasher.Verify(user.Password, password);

                if (isVerifiedPassword)
                {
                    var token = _authorizationService.GetUserToken(user);

                    result.UserId = user.Id;
                    result.RoleId = user.RoleId;
                    result.Token = token;
                    result.IsSuccess = true;
                }
                else
                {
                    result.ErrorMessage = "Incorrect password";
                }
            }
            else
            {
                result.ErrorMessage = $"User with email {email} doesn't exist";
            }

            return result;
        }

        public async Task<AuthModel> RegisterAsync(UserModel model)
        {
            var result = new AuthModel();

            var isUserExist = await _userService.IsUserExistAsync(model.Email);

            if (!isUserExist)
            {
                var hashedPassword = Hasher.Hash(model.Password);

                model.Password = hashedPassword;

                var newUser = await _userService.CreateUserAsync(model);

                var token = _authorizationService.GetUserToken(newUser);

                result.UserId = newUser.Id;
                result.RoleId = newUser.RoleId;
                result.Token = token;
                result.IsSuccess = true;
            }
            else
            {
                result.ErrorMessage = $"User with email {model.Email} already exist";
            }

            return result;
        }
    }
}
