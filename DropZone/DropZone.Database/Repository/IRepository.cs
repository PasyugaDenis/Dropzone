using DropZone.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DropZone.Database.Repository
{
    public interface IRepository
    {
        //Read
        Task<bool> AllAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<bool> AnyAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<bool> AnyAsync<TEntity>() where TEntity : class, IEntity;

        Task<int> CountAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<int> CountAsync<TEntity>() where TEntity : class, IEntity;

        Task<TEntity> GetAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<TEntity> GetOrDefaultAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>() where TEntity : class, IEntity;

        DbContextTransaction BeginTransaction();

        //Write
        Task<TEntity> AddAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> UpdateAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> RemoveAsync<TEntity>(TEntity item) where TEntity : class, IEntity;

        Task<TEntity> RemoveAsync<TEntity>(long id) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> AddRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> UpdateRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> RemoveRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> RemoveRangeAsync<TEntity>(IEnumerable<long> ids) where TEntity : class, IEntity;
    }
}
