
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Context
{
    public class SalesContext:DbContext
    {
        public SalesContext(DbContextOptions<SalesContext>options): base(options) { 
        }

        public DbSet<Venta> Ventas {  get; set; }
        public DbSet<DetalleVenta>DetalleVentas { get; set; }
        public DbSet<TipoDocumentoVenta> TipoDocumentoVentas { get; set; }

    }
}
