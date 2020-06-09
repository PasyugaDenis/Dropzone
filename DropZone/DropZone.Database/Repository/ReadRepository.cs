using DropZone.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DropZone.Database.Repository
{
    public partial class Repository : IRepository
    {
        public async Task<bool> AllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AllAsync(predicate);

            return result;
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AnyAsync(predicate);

            return result;
        }

        public async Task<bool> AnyAsync<TEntity>() where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AnyAsync();

            return result;
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .CountAsync(predicate);

            return result;
        }

        public async Task<int> CountAsync<TEntity>() where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .CountAsync();

            return result;
        }

        public async Task<TEntity> GetAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => m.Id == id)
                .SingleAsync();

            return result;
        }

        public async Task<TEntity> GetOrDefaultAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(predicate)
                .SingleAsync();

            return result;
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(predicate)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(predicate)
                .FirstAsync();

            return result;
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(predicate)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>() where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
