using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Managers.ParachuteManager
{
    public interface IParachuteManager
    {
        Task<ParachuteSystemModel> GetParachuteSystemAsync(long id);

        Task<IEnumerable<ParachuteSystemModel>> GetParachuteSystemsAsync();

        Task<ParachuteSystemModel> CreateParachuteSystemAsync(ParachuteSystemModel model, long userId);

        Task<ParachuteSystemModel> EditParachuteSystemAsync(ParachuteSystemModel model, long userId);
    }
}
