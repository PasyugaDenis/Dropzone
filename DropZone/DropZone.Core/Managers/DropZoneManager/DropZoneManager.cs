using AutoMapper;
using DropZone.Core.Models;
using DropZone.Core.Services.DropZoneService;
using DropZone.Core.Services.UserService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.DropZoneManager
{
    public class DropZoneManager : IDropZoneManager
    {
        private readonly IDropZoneService _dropZoneService;
        private readonly IUserService _userService;

        public DropZoneManager(
            IDropZoneService dropZoneService,
            IUserService userService)
        {
            _dropZoneService = dropZoneService;
            _userService = userService;
        }

        public async Task<DropZoneModel> GetDropZoneAsync(long id)
        {
            var result = await _dropZoneService.GetDropZoneAsync(id);

            return result;
        }

        public async Task<IEnumerable<DropZoneModel>> GetDropZonesAsync()
        {
            var result = await _dropZoneService.GetDropZonesAsync();

            return result;
        }

        public async Task<DropZoneModel> CreateDropZoneAsync(DropZoneModel model, string adminEmail)
        {
            var admin = await _userService.GetUserAsync(adminEmail);
            var adminRole = await _userService.GetAdminRoleAsync();

            if (admin.RoleId == adminRole.Id)
            {
                throw new Exception($"User with email {adminEmail} is already admin of another dropzone");
            }

            admin.RoleId = adminRole.Id;

            var result = await _dropZoneService.CreateDropZoneAsync(model);

            admin.DropZoneId = result.Id;

            await _userService.EditUserAsync(Mapper.Map<UserModel>(admin));

            return result;
        }

        public async Task<DropZoneModel> EditDropZoneAsync(DropZoneModel model)
        {
            var result = await _dropZoneService.EditDropZoneAsync(model);

            return result;
        }
    }
}
