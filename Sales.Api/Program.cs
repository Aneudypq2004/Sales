using Microsoft.EntityFrameworkCore;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Service;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Inteface;
using Sales.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Con Strings
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

//Repositories

builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();

builder.Services.AddScoped<ITipoDocumentoVentaRepository,TipoDocumentoVentaRepository>();

//App Services
builder.Services.AddTransient<ITipoDocumentoVentaService, TipoDocumentoVentaService>();
builder.Services.AddTransient<IVentaService, VentaService>();
builder.Services.AddTransient<IDetalleVentaService, DetalleVentaService>();

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
