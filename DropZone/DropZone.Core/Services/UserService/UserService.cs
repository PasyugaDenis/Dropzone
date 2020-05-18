using AutoMapper;
using DropZone.Core.Models;
using DropZone.Database.Models;
using DropZone.Database.Repository;
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

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _repository.SingleOrDefaultAsync<User>(m => m.Email == email);

            return Mapper.Map<UserModel>(user);
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            var result = await _repository.AnyAsync<User>(m => m.Email == email);

            return result;
        }

        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            var role = await GetSportsmanRoleAsync();

            model.RoleId = role.Id;

            var newUser = await _repository.AddAsync(Mapper.Map<User>(model));

            return Mapper.Map<UserModel>(newUser);
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
