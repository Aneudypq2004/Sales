
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly SalesContext context;
        public DetalleVentaRepository(SalesContext context) { 
            
            this.context = context;
        }

        public void Create(DetalleVenta detalleVenta)
        {
            try
            {
               if (context.DetalleVentas.Any(detalleVenta => detalleVenta.CategoriaProducto == detalleVenta.CategoriaProducto))

                throw new DetalleVentaException("Esta Categoria de venta ya se encuentra registrada");
                this.context.DetalleVentas.Add(detalleVenta);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DetalleVenta? GetDetalleVenta(int id)
        {
            return this.context.DetalleVentas!.Find(id);
        }

        public List<DetalleVenta> GetDetalleVentas()
        {
            return this.context.DetalleVentas
                                             .Where(DetalleVenta=> !DetalleVenta.Eliminado)
                                             .ToList();

        }

        public void Remove(DetalleVenta DetalleVenta)
        {
            try
            {
                var detalleVentaToRemove = this.GetDetalleVenta(DetalleVenta.Id);

                detalleVentaToRemove.Eliminado = true;
                detalleVentaToRemove.FechaElimino = DetalleVenta.FechaElimino;
                detalleVentaToRemove.IdUsuarioElimino = DetalleVenta.IdUsuarioElimino;

                this.context.DetalleVentas?.Update(DetalleVenta);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(DetalleVenta DetalleVenta)
        {
            var detalleVentaToUpdate = this.GetDetalleVenta(DetalleVenta.Id);

            detalleVentaToUpdate.MarcaProducto = DetalleVenta.MarcaProducto;
            detalleVentaToUpdate.DescripcionProducto = DetalleVenta.DescripcionProducto;
            detalleVentaToUpdate.CategoriaProducto = DetalleVenta.CategoriaProducto;
            detalleVentaToUpdate.Cantidad = DetalleVenta.Cantidad;
            detalleVentaToUpdate.Precio = DetalleVenta.Precio;
            detalleVentaToUpdate.Total = DetalleVenta.Total;

         

            this.context.DetalleVentas.Update(detalleVentaToUpdate);
            this.context.SaveChanges();
        }
    }
}
