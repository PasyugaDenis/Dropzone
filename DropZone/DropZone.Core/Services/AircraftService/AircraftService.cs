using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DropZone.Core.Models;
using DropZone.Database.Models;
using DropZone.Database.Repository;

namespace DropZone.Core.Services.AircraftService
{
    public class AircraftService : IAircraftService
    {
        private readonly IRepository _repository;

        public AircraftService(
            IRepository repository)
        {
            _repository = repository;
        }

        public async Task<AircraftModel> CreateAircraftAsync(AircraftModel model)
        {
            var modelEntity = Mapper.Map<Aircraft>(model);

            var newAircraft = await _repository.AddAsync(modelEntity);

            return Mapper.Map<AircraftModel>(newAircraft);
        }

        public async Task<AircraftModel> EditAircraftAsync(AircraftModel model)
        {
            var aircraft = await _repository.GetAsync<Aircraft>(model.Id);

            var isDropZoneExist = await _repository.AnyAsync<Database.Models.DropZone>(m => m.Id == model.DropZoneId);

            if (!isDropZoneExist)
            {
                throw new Exception($"DropZone with Id {model.DropZoneId} is not exist");
            }

            aircraft.Type = model.Type;
            aircraft.Capacity = model.Capacity;
            aircraft.IsAvailable = model.IsAvailable;
            aircraft.DropZoneId = model.DropZoneId;

            var newAircraft = await _repository.UpdateAsync(aircraft);

            return Mapper.Map<AircraftModel>(newAircraft);
        }

        public async Task DeleteAircraftAsync(long id)
        {
            await _repository.RemoveAsync<Aircraft>(id);
        }

        public async Task<AircraftModel> GetAircraftAsync(long id)
        {
            var result = await _repository.GetAsync<Aircraft>(id);

            return Mapper.Map<AircraftModel>(result);
        }

        public async Task<IEnumerable<AircraftModel>> GetAircraftsAsync()
        {
            var result = await _repository.GetAsync<Aircraft>();

            return Mapper.Map<IEnumerable<AircraftModel>>(result);
        }

        public async Task<IEnumerable<AircraftModel>> GetDropZoneAircraftsAsync(long id)
        {
            var result = await _repository.GetAsync<Aircraft>(m => m.DropZoneId == id);

            return Mapper.Map<IEnumerable<AircraftModel>>(result);
        }
    }
}
