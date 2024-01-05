using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

internal class CurrencyConfiguration : IEntityTypeConfiguration<Application.Entities.Currency>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Currency> builder)
    {
    }
}