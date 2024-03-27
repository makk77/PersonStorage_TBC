using PersonStorage.Core.Application.Interfaces.Reports;
using PersonStorage.Core.Application.Interfaces.Repositories;

namespace PersonStorage.Core.Application.Interfaces;

public interface IUnitOfWork
{
    public IPersonRepository PersonRepository { get; }
    public IPersonReport PersonReport { get; }
    public ICityRepository CityRepository { get; }

    Task<int> SaveAsync();
}
