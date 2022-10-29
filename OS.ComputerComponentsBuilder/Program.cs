using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;
using OS.ComputerComponentsBuilder.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddDbContext<ApplicationStorage>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DevConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

await app.Services.SeedAsync();

app.Run();