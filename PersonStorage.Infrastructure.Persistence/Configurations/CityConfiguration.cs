using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonStorage.Core.Domain.Models;
using PersonStorage.Infrastructure.Persistence.Configurations.DataSeed;

namespace PersonStorage.Infrastructure.Persistence.Configurations;

internal class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

        builder.HasData(CitySeed.Tbilisi, CitySeed.Batumi, CitySeed.Kutaisi, CitySeed.Mtsketa);
    }
}
