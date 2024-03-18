using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Contract;
using Sales.Application.Services;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;

namespace Sales.Ioc.ProductDependency
{
    public static class ProductDependency
    {
        public static void AddProductDependency(this IServiceCollection service)
        {
            // Repositories
            service.AddScoped<IProductRepository, ProductRepository>();


            // App Services
            service.AddTransient<IProductService, ProductService>();

        }
    }
}
