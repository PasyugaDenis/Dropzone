using DropZone.Core.Models;
using DropZone.Core.Services.DropZoneService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.DropZoneManager
{
    public class DropZoneManager : IDropZoneManager
    {
        private readonly IDropZoneService _dropZoneService;

        public DropZoneManager(
            IDropZoneService dropZoneService)
        {
            _dropZoneService = dropZoneService;
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

        public async Task<DropZoneModel> CreateDropZoneAsync(DropZoneModel model)
        {
            var result = await _dropZoneService.CreateDropZoneAsync(model);

            return result;
        }

        public async Task<DropZoneModel> EditDropZoneAsync(DropZoneModel model)
        {
            var result = await _dropZoneService.EditDropZoneAsync(model);

            return result;
        }
    }
}
