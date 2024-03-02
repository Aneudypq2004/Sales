using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;
using Sales.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<ILoggerService, LoggerService<Program>>();


builder.Services.AddDbContext<SalesContext>(opt =>
{
    opt.UseSqlServer("Server=ANEPQ;Database=Sales; Trusted_Connection=True; TrustServerCertificate=True;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
