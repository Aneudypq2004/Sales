
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities.Production;

namespace Sales.Infrastructure.Context
{
    public class SalesContext : DbContext 
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categoria { get; set; }

        public DbSet<Product>? Producto { get; set; }

    }
}
