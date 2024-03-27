using Microsoft.EntityFrameworkCore;
using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonStorage.Core.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PersonRegister.Infrastructure.Database.Persistence.Implementations;

internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly PersonDbContext context;
    public Repository(PersonDbContext context) => this.context = context;

    public virtual Task Create(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        return Task.CompletedTask;
    }

    public virtual Task Delete(int id)
    {
        var entity = context.Set<TEntity>().Find(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
        }
        return Task.CompletedTask;
    }

    public virtual Task Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll() => await context.Set<TEntity>().ToListAsync();
    public virtual async Task<TEntity> GetById(int id)
    {
       var res= await context.Set<TEntity>().FindAsync(id);
        return res;
    }
}
