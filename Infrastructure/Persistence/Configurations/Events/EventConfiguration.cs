using Application.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace Infrastructure.Persistence.Configurations.Events;

internal class EventConfiguration : IEntityTypeConfiguration<Application.Entities.Event.Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        //throw new NotImplementedException();
    }
}
