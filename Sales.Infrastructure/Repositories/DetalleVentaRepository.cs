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

        public override bool Exists(Func<DetalleVenta, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<DetalleVenta> GetEntities()
        {
            
            return base.GetEntities().Where(dv =>  dv != null).ToList(); 

        }
        public override void Save(DetalleVenta entity)
        {
            try
            {
                if (context.DetalleVenta!.Any(dv => dv.DescripcionProducto == entity.DescripcionProducto))
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

                detalleVentaToRemove.Id = entity.Id;
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

        public List<DetalleVentaModel> GetDetalleVentaModelByVenta(int IdVenta)
        {
            List<DetalleVentaModel> ventas = new();

            try
            {
                ventas = (from dv in this.context.DetalleVenta
                          join v in this.context.Venta! on dv.IdVenta equals v.Id
                          where dv.IdVenta == IdVenta
                          select new DetalleVentaModel()
                          {
                              Id = dv.Id,
                              IdVenta = v.Id,
                              MarcaProducto = dv.MarcaProducto,
                              DescripcionProducto = dv.DescripcionProducto,
                              CategoriaProducto = dv.CategoriaProducto,
                              Cantidad = dv.Cantidad,
                              Precio = dv.Precio,
                              Total = dv.Total
                          }
                    ).ToList();
                return ventas;
            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo las ventas",e.ToString());
            }

            return ventas;

        }

    }

}
