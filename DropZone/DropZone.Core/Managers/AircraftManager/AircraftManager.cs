using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DropZone.Core.Models;
using DropZone.Core.Services.AircraftService;

namespace DropZone.Core.Managers.AircraftManager
{
    public class AircraftManager : IAircraftManager
    {
        private readonly IAircraftService _aircraftService;

        public AircraftManager(
            IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        public async Task<AircraftModel> CreateAircraftAsync(AircraftModel model)
        {
            var result = await _aircraftService.CreateAircraftAsync(model);

            return result;
        }

        public async Task DeleteAircraftAsync(long id)
        {
            await _aircraftService.DeleteAircraftAsync(id);
        }

        public async Task<AircraftModel> EditAircraftAsync(AircraftModel model)
        {
            var result = await _aircraftService.EditAircraftAsync(model);

            return result;
        }

        public async Task<AircraftModel> GetAircraftAsync(long id)
        {
            var result = await _aircraftService.GetAircraftAsync(id);

            return result;
        }

        public async Task<IEnumerable<AircraftModel>> GetAircraftsAsync()
        {
            var result = await _aircraftService.GetAircraftsAsync();

            return result;
        }

        public async Task<IEnumerable<AircraftModel>> GetDropZoneAircraftsAsync(long id)
        {
            var result = await _aircraftService.GetDropZoneAircraftsAsync(id);

            return result;
        }
    }
}
