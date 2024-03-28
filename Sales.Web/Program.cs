using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Context;
using Sales.Ioc.CategoryDependency;
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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
