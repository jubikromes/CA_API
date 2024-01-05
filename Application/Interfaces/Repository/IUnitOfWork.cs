using Application.Entities;
using Application.Interfaces.Repository.Event;

namespace Application.Interfaces.Repository;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> CommitAsync();
}
