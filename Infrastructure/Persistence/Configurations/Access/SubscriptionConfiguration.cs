using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Access;

internal class SubscriptionConfiguration : IEntityTypeConfiguration<Application.Entities.Access.Subscription>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Access.Subscription> builder)
    {
    }
}