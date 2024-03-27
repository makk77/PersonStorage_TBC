using PersonStorage.API.Middlewares;

namespace PersonStorage.API.Extensions;

public static class IApplicationBuilderExtensions
{
    public static void UsePersonRegisterExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandler>();
    }
}
