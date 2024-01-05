using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class BranchConfiguration : IEntityTypeConfiguration<Application.Entities.Branch>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Branch> builder)
    {
    }
}
