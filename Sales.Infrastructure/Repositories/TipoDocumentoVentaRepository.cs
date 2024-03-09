using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TipoDocumentoVentaRepository> logger;

        public TipoDocumentoVentaRepository(SalesContext context, ILogger<TipoDocumentoVentaRepository> logger) :base (context) {
            
            this.context = context;
            this.logger = logger;
            
        }

        public override List<TipoDocumentoVenta> GetEntities()
        {
            return base.GetEntities().Where(tpdv => !tpdv.Eliminado).ToList(); 
            
        }

        public override void Save(TipoDocumentoVenta entity)
        {
            try
            {
                if (context.TipoDocumentoVenta!.Any(tipoDocumentoVenta => tipoDocumentoVenta.Id == tipoDocumentoVenta.Id))

                    throw new TipoDocumentoVentaException("Este tipo de Documento de Venta ya existe");

                this.context.TipoDocumentoVenta!.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
               this.logger.LogError("Error creando el tipo de documento de venta");
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


                this.context.TipoDocumentoVenta!.Update(tipoDocumentoVentaToRemove);
                this.context.SaveChanges();

            }
            catch (Exception)
            {
                this.logger.LogError("Error eliminando el tipo de documento de venta");

                //this.logger.LogError("Error eliminando el tipo de documento de venta", ex.ToString());
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

                this.context.TipoDocumentoVenta!.Update(tipoDocumentoVentaToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception)
            {
                this.logger.LogError("Error Atualizando el tipo de documento de venta");
            }
        }

        public List<TipoDocumentoVenta> GetTipoDocumentoVentaById(int Id)
        {
            return context.TipoDocumentoVenta!.Where(tdv => tdv.Id.Equals(Id)).ToList();
        }
       
    }
}
