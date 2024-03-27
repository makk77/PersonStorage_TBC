using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonStorage.Core.Application.Interfaces.Services;

namespace PersonStorage.Infrastructure.FileService;

public static class ServiceExtensions
{
    public static void AddFileSystemLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, FileService>(option => new FileService(configuration["Files:Address"]));
    }
}
