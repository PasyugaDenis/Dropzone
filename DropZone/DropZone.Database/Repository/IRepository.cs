using DropZone.Database.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropZone.Database.Repository
{
    public interface IRepository
    {
        //Read
        Task<bool> AllAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<bool> AnyAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<bool> AnyAsync<TEntity>() where TEntity : class, IEntity;

        Task<TEntity> GetAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<TEntity> GetOrDefaultAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<TEntity> GetOrDefaultAsync<TEntity>(long id, TEntity defaultValue) where TEntity : class, IEntity;

        Task<List<TEntity>> GetAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;

        //Write
        Task<TEntity> AddAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> UpdateAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> DeleteAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> DeleteAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<List<TEntity>> AddRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity;

        Task<List<TEntity>> UpdateRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity;

        Task<List<TEntity>> DeleteRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity;

        Task<List<TEntity>> DeleteRangeAsync<TEntity>(List<long> ids) where TEntity : class, IEntity;
    }
}
