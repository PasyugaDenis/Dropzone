using AutoMapper;
using DropZone.Core.Models;
using DropZone.Core.Services.AuthorizationService;
using DropZone.Database.Models;
using DropZone.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropZone.Core.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(
            IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            var result = await _repository.AnyAsync<User>(m => m.Email == email);

            return result;
        }

        public async Task<UserModel> GetUserAsync(string email)
        {
            var user = await _repository.SingleOrDefaultAsync<User>(m => m.Email == email);

            var userModel = Mapper.Map<UserModel>(user);
            userModel.Role = Mapper.Map<RoleModel>(user.Role);

            return userModel;
        }

        public async Task<UserModel> GetUserAsync(long userId)
        {
            var user = await _repository.SingleOrDefaultAsync<User>(m => m.Id == userId);

            var userModel = Mapper.Map<UserModel>(user);
            userModel.Role = Mapper.Map<RoleModel>(user.Role);

            return userModel;
        }

        public async Task<JumpBookModel> GetUserJumpBookAsync(long userId)
        {
            var jumpBook = await _repository.SingleOrDefaultAsync<JumpBook>(m => m.SportsmanId == userId);

            var jumpBookModel = Mapper.Map<JumpBookModel>(jumpBook);
            jumpBookModel.Jumps = Mapper.Map<List<JumpModel>>(jumpBook.Jumps);

            return jumpBookModel;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var result = new List<UserModel>();
            var users = await _repository.GetAsync<User>();

            foreach(var user in users)
            {
                var userModel = Mapper.Map<UserModel>(user);

                userModel.Role = Mapper.Map<RoleModel>(user.Role);
                userModel.DropZone = Mapper.Map<DropZoneModel>(user.DropZone);

                result.Add(userModel);
            }

            return result;
        }

        public async Task<IEnumerable<UserModel>> GetSportsmenAsync()
        {
            var result = new List<UserModel>();
            var users = await _repository.GetAsync<User>(m => m.RoleId == 10);

            foreach (var user in users)
            {
                var userModel = Mapper.Map<UserModel>(user);

                userModel.Role = Mapper.Map<RoleModel>(user.Role);
                userModel.DropZone = Mapper.Map<DropZoneModel>(user.DropZone);

                result.Add(userModel);
            }

            return result;
        }

        public async Task<IEnumerable<UserModel>> GetDropZoneUsersAsync(long dropZoneId)
        {
            var result = new List<UserModel>();
            var users = await _repository.GetAsync<User>(m => m.DropZoneId == dropZoneId);
            var dropZone = await _repository.GetAsync<Database.Models.DropZone>(dropZoneId);

            var dropZoneModel = Mapper.Map<DropZoneModel>(dropZone);

            foreach (var user in users)
            {
                var userModel = Mapper.Map<UserModel>(user);

                userModel.Role = Mapper.Map<RoleModel>(user.Role);
                userModel.DropZone = dropZoneModel;

                result.Add(userModel);
            }

            return result;
        }

        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            var role = await GetSportsmanRoleAsync();

            model.RoleId = role.Id;

            var newUser = await _repository.AddAsync(Mapper.Map<User>(model));

            return Mapper.Map<UserModel>(newUser);
        }

        public async Task<UserModel> EditUserAsync(UserModel model)
        {
            var user = await _repository.GetAsync<User>(model.Id);

            var isUserExist = await IsUserExistAsync(model.Email);

            if (isUserExist)
            {
                throw new Exception($"User with email {model.Email} already exist");
            }

            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Phone = model.Phone;
            user.Address = model.Address;
            user.Birthday = model.Birthday;

            var newUser = await _repository.UpdateAsync(user);

            return Mapper.Map<UserModel>(newUser);
        }

        public async Task DeleteUserAsync(long userId)
        {
            await _repository.RemoveAsync<User>(userId);
        }

        public async Task ChangeUserRoleAsync(long userId, long roleId)
        {
            var user = await _repository.GetAsync<User>(userId);

            var isRoleExist = await _repository.AnyAsync<Role>(m => m.Id == roleId);

            if (!isRoleExist)
            {
                throw new Exception($"Role with id {roleId} not exist");
            }

            user.RoleId = roleId;

            await _repository.UpdateAsync(user);
        }

        public async Task ChangeUserPasswordAsync(UserModel model)
        {
            var user = await _repository.GetAsync<User>(model.Id);

            var hashedPassword = PasswordHasher.HashPassword(model.Password);

            user.Password = hashedPassword;

            await _repository.UpdateAsync(user);
        }

        public async Task<RoleModel> GetSuperAdminRoleAsync()
        {
            var role = await _repository.SingleAsync<Role>(m => m.Value == "SuperAdmin");
            
            return Mapper.Map<RoleModel>(role);
        }

        public async Task<RoleModel> GetAdminRoleAsync()
        {
            var role = await _repository.SingleAsync<Role>(m => m.Value == "Admin");

            return Mapper.Map<RoleModel>(role);
        }

        public async Task<RoleModel> GetManagerRoleAsync()
        {
            var role = await _repository.SingleAsync<Role>(m => m.Value == "Manager");

            return Mapper.Map<RoleModel>(role);
        }

        public async Task<RoleModel> GetLayerRoleAsync()
        {
            var role = await _repository.SingleAsync<Role>(m => m.Value == "Layer");

            return Mapper.Map<RoleModel>(role);
        }

        public async Task<RoleModel> GetSportsmanRoleAsync()
        {
            var role = await _repository.SingleAsync<Role>(m => m.Value == "Sportsman");

            return Mapper.Map<RoleModel>(role);
        }
    }
}
