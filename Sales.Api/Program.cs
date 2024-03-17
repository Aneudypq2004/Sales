using Microsoft.EntityFrameworkCore;
using Sales.Application.Contract;
using Sales.Application.Services;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Conn String
builder.Services.AddDbContext<SalesContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));


// Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// App Services
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();


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
