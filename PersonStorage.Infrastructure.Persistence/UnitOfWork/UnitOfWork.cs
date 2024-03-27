using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonRegister.Infrastructure.Database.Persistence.Implementations;
using PersonRegister.Infrastructure.Database.Persistence.Implementations.Reports;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Application.Interfaces.Reports;
using PersonStorage.Core.Application.Interfaces.Repositories;

namespace PersonRegister.Infrastructure.Database.Persistence.UnitOfWork;
internal class UnitOfWork : IUnitOfWork
{
    private IPersonRepository personRepository;
    private ICityRepository cityRepository;
    private IPersonReport personReport;

    private PersonDbContext context;
    public UnitOfWork(PersonDbContext context) => this.context = context;

    public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);
    public ICityRepository CityRepository => cityRepository ??= new CityRepository(context);
    public IPersonReport PersonReport => personReport ??= new PersonReport(context);

    public async Task<int> SaveAsync()
    {
       return await context.SaveChangesAsync();
    }
}