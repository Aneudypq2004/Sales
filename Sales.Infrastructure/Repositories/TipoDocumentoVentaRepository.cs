using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;


namespace Sales.Infrastructure.Repositories
{
    public class TipoDocumentoVentaRepository : BaseRepository<TipoDocumentoVenta>, ITipoDocumentoVentaRepository
    {
        private readonly SalesContext context;

        public TipoDocumentoVentaRepository(SalesContext context) :base (context) {
            
            this.context = context;
        }

        public override List<TipoDocumentoVenta> GetEntities()
        {
            return base.GetEntities().Where(TipoDocumentoVenta => !TipoDocumentoVenta.Eliminado).ToList(); ;
        }

        public override void Save(TipoDocumentoVenta entity)
        {
            try
            {
                if (context.TipoDocumentoVentas.Any(tipoDocumentoVenta => tipoDocumentoVenta.Id == tipoDocumentoVenta.Id))

                    throw new TipoDocumentoVentaException("Este tipo de Documento de Venta ya existe");

                this.context.TipoDocumentoVentas.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message); ;
            }

        }

        public override void Remove(TipoDocumentoVenta entity)
        {
            try
            {
                var tipoDocumentoVentaToRemove = this.GetEntity(entity.Id) ?? throw new TipoDocumentoVentaException("Este tipo de Documento de Venta no existe para ser eliminado");

                tipoDocumentoVentaToRemove.Eliminado = true;
                tipoDocumentoVentaToRemove.FechaElimino = entity.FechaElimino;
                tipoDocumentoVentaToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;


                this.context.TipoDocumentoVentas.Update(tipoDocumentoVentaToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message);
            }

        }

        public override void Update(TipoDocumentoVenta entity)
        {
            try
            {
                var tipoDocumentoVentaToUpdate = this.GetEntity(entity.Id) ?? throw new TipoDocumentoVentaException("Este tipo de Documento de Venta no existe para ser Actualizado");

                tipoDocumentoVentaToUpdate.Descripcion = entity.Descripcion;
                tipoDocumentoVentaToUpdate.EsActivo = entity.EsActivo;
                tipoDocumentoVentaToUpdate.Eliminado = entity.Eliminado;

                this.context.TipoDocumentoVentas.Update(tipoDocumentoVentaToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new DetalleVentaException(ex.Message);
            }
        }
    }
}
