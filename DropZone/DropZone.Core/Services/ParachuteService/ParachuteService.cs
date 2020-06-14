using AutoMapper;
using DropZone.Core.Models;
using DropZone.Core.Utillities;
using DropZone.Database.Models;
using DropZone.Database.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Core.Services.ParachuteService
{
    public class ParachuteService : IParachuteService
    {
        private readonly IRepository _repository;

        public ParachuteService(
            IRepository repository)
        {
            _repository = repository;
        }

        private async Task<HashBlockModel> CreateHashBlock(string message, long userId)
        {
            var hashValue = $"{DateTime.UtcNow.ToLongDateString()}. USER: {userId}. VALUE: {message}";

            var hashBlock = new HashBlock
            {
                Value = hashValue,
                Hash = Hasher.Hash(message),
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            var result = await _repository.AddAsync(hashBlock);

            return Mapper.Map<HashBlockModel>(result);
        }

        private async Task<HashBlockModel> CreateHashBlock(string message, long userId, HashBlock previousHash)
        {
            var hashValue = $"{DateTime.UtcNow.ToLongDateString()}. USER: {userId}. VALUE: {message}";

            var hashBlock = new HashBlock
            {
                Value = hashValue,
                Hash = Hasher.Hash(message),
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                PreviousHashBlockId = previousHash.Id,
                PreviousHash = previousHash.Hash
            };

            var result = await _repository.AddAsync(hashBlock);

            return Mapper.Map<HashBlockModel>(result);
        }

        private async Task<bool> VerifyHashBlocks(long lastBlockId)
        {
            var hashBlock = await _repository.GetAsync<HashBlock>(lastBlockId);
            HashBlock previousHash;

            while (hashBlock.PreviousHashBlockId.HasValue)
            {
                if (!Hasher.Verify(hashBlock.Hash, hashBlock.Value))
                {
                    throw new Exception($"HashBlock {hashBlock.Id} is not valid");
                }

                previousHash = await _repository.GetAsync<HashBlock>(hashBlock.PreviousHashBlockId.Value);

                if (!Hasher.Verify(hashBlock.PreviousHash, previousHash.Value))
                {
                    throw new Exception($"HashBlocks {hashBlock.Id}, {previousHash.Id} are not valid");
                }

                hashBlock = previousHash;
            }

            return true;
        }

        public async Task<ParachuteSystemModel> CreateParachuteSystemAsync(ParachuteSystemModel model, long userId)
        {
            var message = "Parachute system was created";

            var hashBlock = await CreateHashBlock(message, userId);

            var entity = Mapper.Map<ParachuteSystem>(model);

            entity.MainParachuteId = model.MainParachuteId;
            entity.ReserveParachuteId = model.ReserveParachuteId;
            entity.AADId = model.AADId;
            entity.SatchelId = model.SatchelId;
            entity.UserId = userId;
            entity.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(entity);

            return Mapper.Map<ParachuteSystemModel>(result);
        }

        public async Task<AADModel> CreateAADAsync(AADModel model, long userId)
        {
            var message = "AAD was created";

            var hashBlock = await CreateHashBlock(message, userId);

            var aad = Mapper.Map<AAD>(model);

            aad.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(aad);

            return Mapper.Map<AADModel>(result);
        }

        public async Task<ParachuteModel> CreateMainParachuteAsync(ParachuteModel model, long userId)
        {
            var message = "Main parachute was created";

            var hashBlock = await CreateHashBlock(message, userId);

            var entity = Mapper.Map<Parachute>(model);

            entity.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(entity);

            return Mapper.Map<ParachuteModel>(result);
        }

        public async Task<ParachuteModel> CreateReserveParachuteAsync(ParachuteModel model, long userId)
        {
            var message = "Reserve parachute was created";

            var hashBlock = await CreateHashBlock(message, userId);

            var entity = Mapper.Map<Parachute>(model);

            entity.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(entity);

            return Mapper.Map<ParachuteModel>(result);
        }

        public async Task<SatchelModel> CreateSatchelAsync(SatchelModel model, long userId)
        {
            var message = "Satchel was created";

            var hashBlock = await CreateHashBlock(message, userId);

            var entity = Mapper.Map<Satchel>(model);

            entity.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(entity);

            return Mapper.Map<SatchelModel>(result);
        }

        public async Task<ParachuteSystemModel> EditParachuteSystemAsync(ParachuteSystemModel model, long userId)
        {
            var message = "Parachute system was changed";

            var hashBlock = await CreateHashBlock(message, userId);

            var entity = Mapper.Map<ParachuteSystem>(model);

            entity.MainParachuteId = model.MainParachuteId;
            entity.ReserveParachuteId = model.ReserveParachuteId;
            entity.AADId = model.AADId;
            entity.SatchelId = model.SatchelId;
            entity.UserId = userId;
            entity.HashBlockId = hashBlock.Id;

            var result = await _repository.AddAsync(entity);

            return Mapper.Map<ParachuteSystemModel>(result);
        }

        public async Task<AADModel> EditAADAsync(AADModel model, long userId)
        {
            var entity = await _repository.GetAsync<AAD>(model.Id);

            await VerifyHashBlocks(entity.HashBlockId);

            var message = "AAD was changed";

            var newHashBlock = await CreateHashBlock(message, userId, entity.HashBlock);

            entity.MaintenanceDate = model.MaintenanceDate;
            entity.AADTypeId = model.AADTypeId;

            entity.HashBlockId = newHashBlock.Id;

            var result = await _repository.UpdateAsync(entity);

            return Mapper.Map<AADModel>(result);
        }

        public async Task<ParachuteModel> EditMainParachuteAsync(ParachuteModel model, long userId)
        {
            var entity = await _repository.GetAsync<Parachute>(model.Id);

            await VerifyHashBlocks(entity.HashBlockId);

            var message = "Main parachute was changed";

            var newHashBlock = await CreateHashBlock(message, userId, entity.HashBlock);

            entity.Area = model.Area;
            entity.LayingVolume = model.LayingVolume;
            entity.Weight = model.Weight;
            entity.LayingCount = model.LayingCount;
            entity.SectionCount = model.SectionCount;
            entity.IsReserve = model.IsReserve;
            entity.LayingDate = model.LayingDate;
            entity.MaintenanceDate = model.MaintenanceDate;
            entity.ManufacturerId = model.ManufacturerId;

            entity.HashBlockId = newHashBlock.Id;

            var result = await _repository.UpdateAsync(entity);

            return Mapper.Map<ParachuteModel>(result);
        }

        public async Task<ParachuteModel> EditReserveParachuteAsync(ParachuteModel model, long userId)
        {
            var entity = await _repository.GetAsync<Parachute>(model.Id);

            await VerifyHashBlocks(entity.HashBlockId);

            var message = "Reserve parachute was changed";

            var newHashBlock = await CreateHashBlock(message, userId, entity.HashBlock);

            entity.Area = model.Area;
            entity.LayingVolume = model.LayingVolume;
            entity.Weight = model.Weight;
            entity.LayingCount = model.LayingCount;
            entity.SectionCount = model.SectionCount;
            entity.IsReserve = model.IsReserve;
            entity.LayingDate = model.LayingDate;
            entity.MaintenanceDate = model.MaintenanceDate;
            entity.ManufacturerId = model.ManufacturerId;

            entity.HashBlockId = newHashBlock.Id;

            var result = await _repository.UpdateAsync(entity);

            return Mapper.Map<ParachuteModel>(result);
        }

        public async Task<SatchelModel> EditSatchelAsync(SatchelModel model, long userId)
        {
            var entity = await _repository.GetAsync<Satchel>(model.Id);

            await VerifyHashBlocks(entity.HashBlockId);

            var message = "Satchel was changed";

            var newHashBlock = await CreateHashBlock(message, userId, entity.HashBlock);

            entity.MainParachuteArea = model.MainParachuteArea;
            entity.ReserveParachuteArea = model.ReserveParachuteArea;
            entity.MaintenanceDate = model.MaintenanceDate;

            entity.HashBlockId = newHashBlock.Id;

            var result = await _repository.UpdateAsync(entity);

            return Mapper.Map<SatchelModel>(result);
        }

        public async Task<ParachuteSystemModel> GetParachuteSystemAsync(long id)
        {
            var parachuteSystem = await _repository.GetAsync<ParachuteSystem>(id);

            if (await VerifyHashBlocks(parachuteSystem.HashBlockId.Value) ||
                await VerifyHashBlocks(parachuteSystem.MainParachute.HashBlockId) ||
                await VerifyHashBlocks(parachuteSystem.ReserveParachute.HashBlockId) ||
                await VerifyHashBlocks(parachuteSystem.AAD.HashBlockId) ||
                await VerifyHashBlocks(parachuteSystem.Satchel.HashBlockId))
            {
                throw new Exception($"ParachuteSystem {parachuteSystem.Id} is not valid");
            }

            var result = Mapper.Map<ParachuteSystemModel>(parachuteSystem);

            result.MainParachute = Mapper.Map<ParachuteModel>(parachuteSystem.MainParachute);
            result.ReserveParachute = Mapper.Map<ParachuteModel>(parachuteSystem.ReserveParachute);
            result.AAD = Mapper.Map<AADModel>(parachuteSystem.AAD);
            result.AAD.AADType = Mapper.Map<AADTypeModel>(parachuteSystem.AAD.AADType);
            result.Satchel = Mapper.Map<SatchelModel>(parachuteSystem.Satchel);

            return result;
        }

        public async Task<IEnumerable<ParachuteSystemModel>> GetParachuteSystemsAsync()
        {
            var result = new List<ParachuteSystemModel>();
            var parachuteSystems = await _repository.GetAsync<ParachuteSystem>();

            foreach (var item in parachuteSystems)
            {
                var model = await GetParachuteSystemAsync(item.Id);

                result.Add(model);
            }

            return result;
        }
    }
}
