using DropZone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropZone.Core.Services.DropZoneService
{
    public interface IDropZoneService
    {
        Task<DropZoneModel> GetDropZoneAsync(long id);

        Task<IEnumerable<DropZoneModel>> GetDropZonesAsync();

        Task<DropZoneModel> CreateDropZoneAsync(DropZoneModel model);

        Task<DropZoneModel> EditDropZoneAsync(DropZoneModel model);
    }
}
