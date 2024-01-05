using Application.Entities;
using Application.Interfaces.Repository;
using Application.Interfaces.Repository.Event;
using Infrastructure.Persistence.Repository;
using MediatR;
using System.Collections;

namespace Infrastructure.Persistence.DbConfiguration;

public class UnitOfWork(ConfamAppDbContext context, IMediator mediator) : IUnitOfWork
{
    private readonly ConfamAppDbContext _context = context;
    private readonly IMediator _mediator = mediator;
    private Hashtable _repositories;


    public async Task<bool> CommitAsync()
    {
        var result = await _context.SaveChangesAsync() > 0;
        await _mediator.DispatchDomainEventsAsync(_context);
        return result;
    }
    public void Dispose() => _context.Dispose();

    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        _repositories ??= [];

        var type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(BaseRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }
        return (IRepository<TEntity>)_repositories[type];
    }
}
