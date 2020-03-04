using DropZone.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropZone.Database.Repository
{
    public partial class Repository : IRepository
    {
        public async Task<bool> AllAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync<TEntity>() where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetOrDefaultAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetOrDefaultAsync<TEntity>(long id, TEntity defaultValue) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
}
