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

        private readonly ILogger<DetalleVentaRepository> logger;
        public DetalleVentaRepository(SalesContext context, ILogger<DetalleVentaRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<DetalleVenta> GetEntities()
        {
            return context.DetalleVenta!.ToList();

        }
        public override void Save(DetalleVenta entity)
        {
            try
            {
                if (context.DetalleVenta!.Any(dv => dv.DescripcionProducto == dv.DescripcionProducto))
                    throw new DetalleVentaException("Esta Categoria de venta ya se encuentra registrada");
                
                this.context.DetalleVenta!.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Error creando el detalle de venta");
            }
        }

        public override void Remove(DetalleVenta entity)
        {   
            try
            {
                var detalleVentaToRemove = this.GetEntity(entity.Id)?? throw new DetalleVentaException("Este detalle de venta no se puede eliminar porque no existe") ;

                this.context.DetalleVenta!.Update(entity);
                this.context.SaveChanges();

            }
            catch (Exception)
            {
                this.logger.LogError("Error eliminando el detalle de venta");
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
                
                
                this.context.DetalleVenta!.Update(detalleVentaToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Error actualizando el detalle de venta");
            }
        }

        public List<DetalleVenta> GetDetalleVentaModelByVenta(int IdVenta)
        {
            //List<DetalleVenta> ventas = new List<DetalleVenta>();

            return context.DetalleVenta!.Where(dv => dv.IdVenta.Equals(IdVenta)).ToList();

        }

        public List<DetalleVenta> GetDetalleVentaModelByProducto(int IdProducto)
        {
            return context.DetalleVenta!.Where(dv => dv.IdProducto.Equals(IdProducto)).ToList();
        }
    }

}
