using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.DropZoneManager
{
    public interface IDropZoneManager
    {
        Task<DropZoneModel> GetDropZoneAsync(long id);

        Task<IEnumerable<DropZoneModel>> GetDropZonesAsync();

        Task<DropZoneModel> CreateDropZoneAsync(DropZoneModel model);

        Task<DropZoneModel> EditDropZoneAsync(DropZoneModel model);
    }
}
