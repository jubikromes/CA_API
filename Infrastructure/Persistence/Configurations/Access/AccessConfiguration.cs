using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Access;

internal class AccessConfiguration : IEntityTypeConfiguration<Application.Entities.Access.Access>
{
    public void Configure(EntityTypeBuilder<Application.Entities.Access.Access> builder)
    {
        //throw new NotImplementedException();

        builder.HasOne(p => p.Company);
        builder.HasOne(p => p.Currency);
        builder.HasOne(p => p.Branch);

    }
}
