using Application.Entities;
using Application.Entities.Access;
using Application.Entities.Event;
using MassTransit.Courier.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Infrastructure.Persistence;

public class ConfamAppDbContext : DbContext
{
    public ConfamAppDbContext(DbContextOptions<ConfamAppDbContext> options)
      : base(options)
    {

    }
    #region Events
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAgent> EventAgents { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Branch> Branches { get; set; }
    #endregion

    #region Access
    public DbSet<Access> Accesses { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Pass> Passes { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Application.Entities.Access.Subscription> Subscriptions { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public class C2BAutoCompleteDbContextFactory : IDesignTimeDbContextFactory<ConfamAppDbContext>
{
    public ConfamAppDbContext CreateDbContext(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ConfamAppDbContext>();
#if DEBUG
        optionsBuilder.UseSqlServer("Server=.;Database=ConfamAppDb;Trusted_Connection=True;Encrypt=False");
#endif
        return new ConfamAppDbContext(optionsBuilder.Options);
    }
}
