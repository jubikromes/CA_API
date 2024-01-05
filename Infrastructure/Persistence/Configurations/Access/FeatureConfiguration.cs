using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Access;

internal class FeatureConfiguration : IEntityTypeConfiguration<Application.Entities.Access.Feature>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Access.Feature> builder)
    {
    }
}