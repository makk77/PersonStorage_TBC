using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonRegister.Infrastructure.Database.Persistence.UnitOfWork;
using PersonStorage.Core.Application.Interfaces;

namespace PersonRegister.Infrastructure.Database;

public static class DependencyInjection
{
    public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<PersonDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PersonDbConnection")));
    }
}
