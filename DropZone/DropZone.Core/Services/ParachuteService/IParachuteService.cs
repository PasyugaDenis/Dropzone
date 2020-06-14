using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Services.ParachuteService
{
    public interface IParachuteService
    {
        Task<ParachuteSystemModel> GetParachuteSystemAsync(long id);

        Task<IEnumerable<ParachuteSystemModel>> GetParachuteSystemsAsync();

        Task<ParachuteSystemModel> CreateParachuteSystemAsync(ParachuteSystemModel model, long userId);

        Task<ParachuteModel> CreateMainParachuteAsync(ParachuteModel model, long userId);

        Task<ParachuteModel> CreateReserveParachuteAsync(ParachuteModel model, long userId);

        Task<AADModel> CreateAADAsync(AADModel model, long userId);

        Task<SatchelModel> CreateSatchelAsync(SatchelModel model, long userId);

        Task<ParachuteSystemModel> EditParachuteSystemAsync(ParachuteSystemModel model, long userId);

        Task<ParachuteModel> EditMainParachuteAsync(ParachuteModel model, long userId);

        Task<ParachuteModel> EditReserveParachuteAsync(ParachuteModel model, long userId);

        Task<AADModel> EditAADAsync(AADModel model, long userId);

        Task<SatchelModel> EditSatchelAsync(SatchelModel model, long userId);
    }
}
