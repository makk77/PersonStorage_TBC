using System.Collections.Generic;
using System.Linq.Expressions;

namespace PersonStorage.Core.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}
