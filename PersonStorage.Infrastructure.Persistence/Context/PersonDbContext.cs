using Microsoft.EntityFrameworkCore;
using PersonStorage.Core.Domain.Models;
using PersonStorage.Infrastructure.Persistence.Configurations;

namespace PersonRegister.Infrastructure.Database.Persistence.Context;

internal class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
    public DbSet<Person> People { get; private set; }
    public DbSet<City> Cities { get; private set; }
    public DbSet<PersonRelation> PersonRelations { get; private set; }
    public DbSet<Phone> Phones { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new PersonRelationConfiguration());
    }
}
