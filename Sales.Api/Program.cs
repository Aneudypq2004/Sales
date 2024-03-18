using Microsoft.EntityFrameworkCore;
using Sales.Ioc.CategoryDependency;
using Sales.Infrastructure.Context;
using Sales.Ioc.ProductDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Conn String
builder.Services.AddDbContext<SalesContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));


// Dependencies
    // Category
builder.Services.AddCategoryDependency();

    // Product
builder.Services.AddProductDependency();



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
