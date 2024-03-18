using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Contract;
using Sales.Application.Services;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;

namespace Sales.Ioc.CategoryDependency
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection service)
        {
            // Repositories
            service.AddScoped<ICategoryRepository, CategoryRepository>();


            // App Services
            service.AddTransient<ICategoryService, CategoryService>();

        }
    }
}
