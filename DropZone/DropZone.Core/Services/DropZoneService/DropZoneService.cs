using AutoMapper;
using DropZone.Core.Models;
using DropZone.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropZone.Core.Services.DropZoneService
{
    public class DropZoneService : IDropZoneService
    {
        private readonly IRepository _repository;

        public DropZoneService(
            IRepository repository)
        {
            _repository = repository;
        }

        public async Task<DropZoneModel> CreateDropZoneAsync(DropZoneModel model)
        {
            var modelEntity = Mapper.Map<Database.Models.DropZone>(model);

            var newDropZone = await _repository.AddAsync(modelEntity);

            return Mapper.Map<DropZoneModel>(newDropZone);
        }

        public async Task<DropZoneModel> EditDropZoneAsync(DropZoneModel model)
        {
            var dropZone = await _repository.GetAsync<Database.Models.DropZone>(model.Id);

            dropZone.Title = model.Title;
            dropZone.Country = model.Country;
            dropZone.RunwayType = model.RunwayType;
            dropZone.RunwayLength = model.RunwayLength;
            dropZone.Square = model.Square;
            dropZone.Latitude = model.Latitude;
            dropZone.Longitude = model.Longitude;

            var newDropZone = await _repository.UpdateAsync(dropZone);

            return Mapper.Map<DropZoneModel>(newDropZone);
        }

        public async Task<IEnumerable<DropZoneModel>> GetDropZonesAsync()
        {
            var dropZones = await _repository.GetAsync<Database.Models.DropZone>();

            return Mapper.Map<IEnumerable<DropZoneModel>>(dropZones);
        }

        public async Task<DropZoneModel> GetDropZoneAsync(long id)
        {
            var dropZone = await _repository.GetAsync<Database.Models.DropZone>(id);

            return Mapper.Map<DropZoneModel>(dropZone);
        }
    }
}
