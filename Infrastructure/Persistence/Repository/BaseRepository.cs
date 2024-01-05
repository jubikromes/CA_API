using Application.Entities;
using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    internal ConfamAppDbContext context;
    internal DbSet<TEntity> dbSet;

    public BaseRepository(ConfamAppDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }
    public virtual IEnumerable<TEntity> GetWithRawSql(string query,
        params object[] parameters)
    {
        return dbSet.FromSqlRaw(query, parameters).ToList();

    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }


        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity> GetByIdAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }
    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }
    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        entityToDelete.IsDeleted = true;
    }

    public virtual void Remove(TEntity entityToDelete)
    {
        dbSet.Remove(entityToDelete);
    }
    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public void InsertMany(IEnumerable<TEntity> entities)
    {
        dbSet.AddRange(entities);
    }
}
