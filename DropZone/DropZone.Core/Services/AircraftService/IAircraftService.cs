﻿using DropZone.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Services.AircraftService
{
    public interface IAircraftService
    {
        Task<AircraftModel> CreateAircraftAsync(AircraftModel model);

        Task<AircraftModel> EditAircraftAsync(AircraftModel model);

        Task DeleteAircraftAsync(long id);

        Task<IEnumerable<AircraftModel>> GetAircraftsAsync();

        Task<IEnumerable<AircraftModel>> GetDropZoneAircraftsAsync(long id);

        Task<AircraftModel> GetAircraftAsync(long id);
    }
}
