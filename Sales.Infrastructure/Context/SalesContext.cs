
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities.negocios;

namespace Sales.Infrastructure.Context
{
    public class SalesContext:DbContext
    {
        public SalesContext(DbContextOptions<SalesContext>options):base(options) 
        {
            
        }
        public DbSet<Negocio>? Negocio { get; set; }
        public DbSet<NumeroCorrelativo>? NumeroCorrelativo { get; set; }

    }
}
