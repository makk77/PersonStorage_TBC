using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonRegister.Infrastructure.Database.Persistence.Context;

namespace PersonStorage.Infrastructure.Persistence.Extensions;

public static class MigrationExtensions
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            try
            {
                //Auto Migration

                //var context = serviceScope.ServiceProvider.GetService<PersonDbContext>();
                //context.Database.Migrate();
                //context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
