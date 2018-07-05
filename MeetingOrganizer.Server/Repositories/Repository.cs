using MeetingOrganizer.Server.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace MeetingOrganizer.Server.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public TEntity Get(int id)
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return queryable.SingleOrDefault(s => s.Id == id);
            }
        }

        public async Task<TEntity> GetAsync(int id)
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return await queryable.SingleOrDefaultAsync(s => s.Id == id);
            }
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return queryable.Where(predicate).ToList();
            }
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return await queryable.Where(predicate).ToListAsync();
            }
        }

        public bool TryGet(int id, out TEntity entity)
        {
            return (entity = Get(id)) != null;
        }

        public bool TryGetSingle(Expression<Func<TEntity, bool>> predicate, out TEntity entity)
        {
            using (GetContext(out var entities))
            {
                return (entity = entities.SingleOrDefault(predicate)) != null;
            }
        }

        public IList<TEntity> GetAll()
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return queryable.ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (GetContext(out var entities))
            {
                var queryable = OnGetting(entities);
                return await queryable.ToListAsync();
            }
        }

        protected virtual IQueryable<TEntity> OnGetting(DbSet<TEntity> entities)
        {
            return entities;
        }

        public void Add(TEntity entity)
        {
            using (var context = GetContext(out var entities))
            {
                entities.Add(entity);
                context.SaveChanges();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            using (var context = GetContext(out var entities))
            {
                entities.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public bool Delete(int id)
        {
            using (var context = GetContext(out var entities))
            {
                if (entities.Any(a => a.Id == id))
                {
                    entities.Remove(entities.Find(id));
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = GetContext(out var entities))
            {
                if (entities.Any(a => a.Id == id))
                {
                    entities.Remove(await entities.FindAsync(id));
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var context = GetContext(out var entities))
            {
                entities.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (var context = GetContext(out var entities))
            {
                entities.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public bool Contains(int id)
        {
            using (GetContext(out var entities))
            {
                return entities.Any(a => a.Id == id);
            }
        }

        public async Task<bool> ContainsAsync(int id)
        {
            using (GetContext(out var entities))
            {
                return await entities.AnyAsync(a => a.Id == id);
            }
        }

        protected MeetingOrganizerDbContext GetContext(out DbSet<TEntity> entities)
        {
            var context = new MeetingOrganizerDbContext();
            entities = context.Set<TEntity>();
            return context;
        }
    }
}