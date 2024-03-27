using FluentValidation.AspNetCore;
using PersonRegister.Infrastructure.Database;
using PersonStorage.API.ActionFilters;
using PersonStorage.API.Extensions;
using PersonStorage.Core.Application;
using PersonStorage.Infrastructure.FileService;
using PersonStorage.Infrastructure.Persistence.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    var supportedCultures = new[] { "ka-GE", "en-US" };
    option.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

// Add services to the container.
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddDatabaseLayer(builder.Configuration);
builder.Services.AddFileSystemLayer(builder.Configuration);

builder.Services.AddControllers().AddDataAnnotationsLocalization();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonStorage", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonStorage V1");
    });
}


app.MigrateDatabase();
app.UseRequestLocalization();
app.UsePersonRegisterExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
