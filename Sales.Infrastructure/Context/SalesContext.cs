
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Context
{
    public class SalesContext:DbContext
    {
        public SalesContext(DbContextOptions<SalesContext>options): base(options) { 
        }

        public DbSet<Venta>? Venta {  get; set; }
        public DbSet<DetalleVenta>?DetalleVenta { get; set; }
        public DbSet<TipoDocumentoVenta>? TipoDocumentoVenta { get; set; }

    }
}
