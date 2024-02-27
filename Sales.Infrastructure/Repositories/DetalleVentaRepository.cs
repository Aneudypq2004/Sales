
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class DetalleVentaRepository : BaseRepository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly SalesContext context;
        public DetalleVentaRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public override List<DetalleVenta> GetEntities()
        {
            return base.GetEntities().Where(detalleVenta =>!detalleVenta.Eliminado).ToList();
        }
        public override void Save(DetalleVenta entity)
        {
            try
            {
                if (context.DetalleVentas.Any(detalleVenta => detalleVenta.CategoriaProducto == detalleVenta.CategoriaProducto))

                    throw new DetalleVentaException("Esta Categoria de venta ya se encuentra registrada");
                
                this.context.DetalleVentas.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message);
            }
        }

        public override void Remove(DetalleVenta entity)
        {
            try
            {
                var detalleVentaToRemove = this.GetEntity(entity.Id)?? throw new DetalleVentaException("Este detalle de venta no se puede eliminar porque no existe") ;

                detalleVentaToRemove.Eliminado = true;
                detalleVentaToRemove.FechaElimino = entity.FechaElimino;
                detalleVentaToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

                this.context.DetalleVentas?.Update(entity);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message); ;
            }
        }

        public override void Update(DetalleVenta entity)
        {
            try
            {
                var detalleVentaToUpdate = this.GetEntity(entity.Id)?? throw new DetalleVentaException("Este detalle de venta no se puede actualizar porque no existe");

                detalleVentaToUpdate.MarcaProducto = entity.MarcaProducto;
                detalleVentaToUpdate.DescripcionProducto = entity.DescripcionProducto;
                detalleVentaToUpdate.CategoriaProducto = entity.CategoriaProducto;
                detalleVentaToUpdate.Cantidad = entity.Cantidad;
                detalleVentaToUpdate.Precio = entity.Precio;
                detalleVentaToUpdate.Total = entity.Total;
                
                
                this.context.DetalleVentas.Update(detalleVentaToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message);
            }
        }

        

    }

}
