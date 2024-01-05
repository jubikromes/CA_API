using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class CompanyConfiguration : IEntityTypeConfiguration<Application.Entities.Company>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Company> builder)
    {
    }
}