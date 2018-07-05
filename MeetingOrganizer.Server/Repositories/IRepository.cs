using MeetingOrganizer.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace MeetingOrganizer.Server.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        bool TryGet(int id, out TEntity entity);
        bool TryGetSingle(Expression<Func<TEntity, bool>> predicate, out TEntity entity);
        IList<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        bool Delete(int id);
        Task<bool> DeleteAsync(int id);

        bool Contains(int id);
        Task<bool> ContainsAsync(int id);
    }
}