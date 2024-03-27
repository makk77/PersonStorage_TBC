using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Infrastructure.Persistence.Configurations;

internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Number).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NumberType).IsRequired();
        builder.Property(x => x.PersonId).IsRequired();
    }
}
