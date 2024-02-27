

using Sales.Domain.Entities;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly SalesContext context;

        public VentaRepository(SalesContext context) : base(context){ 
            
            this.context = context;
        }

        public override List<Venta> GetEntities()
        {
            return base.GetEntities().Where(venta => !venta.Eliminado)
                        .ToList();
        }

        public override void Save(Venta entity)
        {
            try
            {
                if (context.Ventas.Any(venta => venta.NumeroVenta == venta.NumeroVenta))

                    throw new VentaException("Este numero de venta ya se encuentra registrado");

                this.context.Ventas.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message); ;
            }
        }

        public override void Remove(Venta entity)
        {
            try
            {
                var ventaToRemove = this.GetEntity(entity.Id) ?? throw new TipoDocumentoVentaException("Este tipo de Documento de Venta ya existe");

                ventaToRemove.Eliminado = true;
                ventaToRemove.FechaElimino = entity.FechaElimino;
                ventaToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

                this.context.Ventas.Update(ventaToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DetalleVentaException(ex.Message);
            }
        }

        public override void Update(Venta entity)
        {
            try
            {
                var ventaToUpdate = this.GetEntity(entity.Id);

                ventaToUpdate!.NombreCliente = entity.NombreCliente;
                ventaToUpdate.CocumentoCliente = entity.CocumentoCliente;
                ventaToUpdate.SubTotal = entity.SubTotal;
                ventaToUpdate.ImpuestoTotal = entity.ImpuestoTotal;
                ventaToUpdate.Total = entity.Total;

                this.context.Ventas.Update(ventaToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception ex){
                throw new DetalleVentaException(ex.Message);
            }
        }
    }
}
