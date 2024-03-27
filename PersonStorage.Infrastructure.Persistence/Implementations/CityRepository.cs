using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonStorage.Core.Application.Interfaces.Repositories;
using PersonStorage.Core.Domain.Models;

namespace PersonRegister.Infrastructure.Database.Persistence.Implementations;

internal class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(PersonDbContext context) : base(context) { }
}
