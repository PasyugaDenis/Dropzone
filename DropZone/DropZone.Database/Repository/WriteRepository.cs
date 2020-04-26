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
        public async Task<TEntity> AddAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            item.ModifiedAt = DateTime.UtcNow;

            var result = _context.Set<TEntity>().Add(item);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            item.ModifiedAt = DateTime.UtcNow;

            var entity = _context.Set<TEntity>().Find(item.Id);

            if (entity == null)
            {
                throw new ArgumentException($"The model with Id {item.Id} is not exist in the DB");
            }
            else
            {
                _context.Entry(entity).CurrentValues.SetValues(item);
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<TEntity> RemoveAsync<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            var result = await RemoveAsync<TEntity>(item.Id);

            return result;
        }

        public async Task<TEntity> RemoveAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                throw new ArgumentException($"The model with Id {id} is not exist in the DB");
            }
            else
            {
                _context.Set<TEntity>().Remove(entity);
            }

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity
        {
            foreach (var item in items)
            {
                item.ModifiedAt = DateTime.UtcNow;
            }

            var result = _context.Set<TEntity>().AddRange(items);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity
        {
            foreach (var item in items)
            {
                item.ModifiedAt = DateTime.UtcNow;

                var entity = _context.Set<TEntity>().Find(item.Id);

                if (entity == null)
                {
                    throw new ArgumentException($"The model with Id {item.Id} is not exist in the DB");
                }
                else
                {
                    _context.Entry(entity).CurrentValues.SetValues(item);
                    _context.Entry(entity).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();

            return items;
        }

        public async Task<IEnumerable<TEntity>> RemoveRangeAsync<TEntity>(IEnumerable<TEntity> items) where TEntity : class, IEntity
        {
            var result = await RemoveRangeAsync<TEntity>(items.Select(m => m.Id));

            return result;
        }

        public async Task<IEnumerable<TEntity>> RemoveRangeAsync<TEntity>(IEnumerable<long> ids) where TEntity : class, IEntity
        {
            var result = new List<TEntity>();

            foreach (var id in ids)
            {
                var entity = _context.Set<TEntity>().Find(id);

                if (entity == null)
                {
                    throw new ArgumentException($"The model with Id {id} is not exist in the DB");
                }
                else
                {
                    _context.Set<TEntity>().Remove(entity);
                    result.Add(entity);
                }
            }

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
