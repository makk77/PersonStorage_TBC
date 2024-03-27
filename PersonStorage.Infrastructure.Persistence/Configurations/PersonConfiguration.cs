using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonStorage.Core.Domain.Models;
using PersonStorage.Infrastructure.Persistence.Configurations.DataSeed;

namespace PersonStorage.Infrastructure.Persistence.Configurations;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PersonalNumber).HasMaxLength(20).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnType("date").IsRequired();
        builder.Property(x => x.Gender).IsRequired();

        builder.HasIndex(x => x.PersonalNumber).IsUnique();

        builder.HasOne(x => x.City).WithMany(c => c.People).HasForeignKey(x => x.CityId);


        builder.HasData
                    (
                        PersonSeed.MariamKurkumuli,
                        PersonSeed.PavlePavliashvili,
                        PersonSeed.NinoNinidze,
                        PersonSeed.MariamMariamidze
                    );
    }
}
