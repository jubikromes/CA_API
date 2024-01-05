using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Access;

internal class PassConfiguration : IEntityTypeConfiguration<Application.Entities.Access.Pass>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Access.Pass> builder)
    {
    }
}