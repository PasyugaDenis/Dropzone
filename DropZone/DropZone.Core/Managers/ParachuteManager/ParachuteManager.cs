using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DropZone.Core.Models;
using DropZone.Core.Services.ParachuteService;

namespace DropZone.Core.Managers.ParachuteManager
{
    public class ParachuteManager : IParachuteManager
    {
        private readonly IParachuteService _parachuteService;

        public ParachuteManager(
            IParachuteService parachuteService)
        {
            _parachuteService = parachuteService;
        }

        public async Task<ParachuteSystemModel> CreateParachuteSystemAsync(ParachuteSystemModel model, long userId)
        {
            var mainParachuteModel = Mapper.Map<ParachuteModel>(model.MainParachute);
            var reserveParachuteModel = Mapper.Map<ParachuteModel>(model.MainParachute);
            var aadModel = Mapper.Map<AADModel>(model.AAD);
            var satchelModel = Mapper.Map<SatchelModel>(model.Satchel);

            var newMainParachute = await _parachuteService.CreateMainParachuteAsync(mainParachuteModel, userId);
            var newReserveParachute = await _parachuteService.CreateReserveParachuteAsync(reserveParachuteModel, userId);
            var newAAD = await _parachuteService.CreateAADAsync(aadModel, userId);
            var newSatchel = await _parachuteService.CreateSatchelAsync(satchelModel, userId);

            model.MainParachuteId = newMainParachute.Id;
            model.ReserveParachuteId = newReserveParachute.Id;
            model.AADId = newAAD.Id;
            model.SatchelId = newSatchel.Id;
            model.UserId = userId;

            var result = await _parachuteService.CreateParachuteSystemAsync(model, userId);

            return Mapper.Map<ParachuteSystemModel>(result);
        }

        public async Task<ParachuteSystemModel> EditParachuteSystemAsync(ParachuteSystemModel model, long userId)
        {
            var mainParachuteModel = Mapper.Map<ParachuteModel>(model.MainParachute);
            var reserveParachuteModel = Mapper.Map<ParachuteModel>(model.MainParachute);
            var aadModel = Mapper.Map<AADModel>(model.AAD);
            var satchelModel = Mapper.Map<SatchelModel>(model.Satchel);

            var newMainParachute = await _parachuteService.EditMainParachuteAsync(mainParachuteModel, userId);
            var newReserveParachute = await _parachuteService.EditReserveParachuteAsync(reserveParachuteModel, userId);
            var newAAD = await _parachuteService.EditAADAsync(aadModel, userId);
            var newSatchel = await _parachuteService.EditSatchelAsync(satchelModel, userId);

            model.MainParachuteId = newMainParachute.Id;
            model.ReserveParachuteId = newReserveParachute.Id;
            model.AADId = newAAD.Id;
            model.SatchelId = newSatchel.Id;
            model.UserId = userId;

            var result = await _parachuteService.EditParachuteSystemAsync(model, userId);

            return Mapper.Map<ParachuteSystemModel>(result);
        }

        public async Task<ParachuteSystemModel> GetParachuteSystemAsync(long id)
        {
            var result = await _parachuteService.GetParachuteSystemAsync(id);

            return result;
        }

        public async Task<IEnumerable<ParachuteSystemModel>> GetParachuteSystemsAsync()
        {
            var result = await _parachuteService.GetParachuteSystemsAsync();

            return result;
        }
    }
}
