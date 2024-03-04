using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

builder.Services.AddScoped<INegocioRepository,NegocioRepocitory>();
builder.Services.AddScoped<INumeroCorrelativoRepository,NumeroCorrelativoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
