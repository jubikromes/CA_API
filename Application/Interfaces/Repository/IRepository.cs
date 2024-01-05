using Application.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByIdAsync(object id);
        IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters);
        void Insert(TEntity entity);
        void InsertMany(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);
        void Remove(TEntity entityToDelete);
    }
}
