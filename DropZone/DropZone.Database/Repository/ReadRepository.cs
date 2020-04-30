using DropZone.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DropZone.Database.Repository
{
    public partial class Repository : IRepository
    {
        public async Task<bool> AllAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AllAsync(i => match(i));

            return result;
        }

        public async Task<bool> AnyAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AnyAsync(i => match(i));

            return result;
        }

        public async Task<bool> AnyAsync<TEntity>() where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .AnyAsync();

            return result;
        }

        public async Task<int> CountAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .CountAsync(i => match(i));

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

        public async Task<TEntity> SingleAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => match(m))
                .SingleAsync();

            return result;
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => match(m))
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<TEntity> FirstAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => match(m))
                .FirstAsync();

            return result;
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(m => match(m))
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Predicate<TEntity> match) where TEntity : class, IEntity
        {
            var result = await _context.Set<TEntity>().AsNoTracking()
                .Where(i => match(i))
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
