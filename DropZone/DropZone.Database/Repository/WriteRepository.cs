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
        public async Task<TEntity> AddAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> AddRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> DeleteAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> DeleteAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> DeleteRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> DeleteRangeAsync<TEntity>(List<long> ids) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> UpdateRangeAsync<TEntity>(List<TEntity> items) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
}
