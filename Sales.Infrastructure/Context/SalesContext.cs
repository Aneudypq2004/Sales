using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities.ModuloUsuario;
using Sales.Domain.Entities.Usuario.Usuario;

namespace Sales.Infrastructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) :base(options)
        {
            
        }

        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Configuracion>? Configuracion { get; set; }

        public DbSet<Rol>? Rol { get; set; }

    }
}
