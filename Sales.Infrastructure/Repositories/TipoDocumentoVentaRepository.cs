using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class TipoDocumentoVentaRepository : ITipoDocumentoVentaRepository
    {
        private readonly SalesContext context;
        public TipoDocumentoVentaRepository(SalesContext context) {
            
            this.context = context;
        }

        public void Create(TipoDocumentoVenta tipoDocumentoVenta)
        {
            try
            {
                if (context.TipoDocumentoVentas.Any(tipoDocumentoVenta => tipoDocumentoVenta.Id == tipoDocumentoVenta.Id))

                    throw new TipoDocumentoVentaException("Este tipo de Documento de Venta ya existe");

                this.context.TipoDocumentoVentas.Add(tipoDocumentoVenta);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public TipoDocumentoVenta? GetTipoDocumentoVenta(int id)
        {
            return this.context.TipoDocumentoVentas!.Find(id);
        }

        public List<TipoDocumentoVenta> GetTipoDocumentoVentas()
        {
            return this.context.TipoDocumentoVentas.Where(TipoDocumentoVenta => !TipoDocumentoVenta.Eliminado).ToList();
        }

        public void Remove(TipoDocumentoVenta tipoDocumentoVenta)
        {
            try
            {
                var tipoDocumentoVentaToRemove = this.GetTipoDocumentoVenta(tipoDocumentoVenta.Id);

                tipoDocumentoVentaToRemove.Eliminado = true;
                tipoDocumentoVentaToRemove.FechaElimino = tipoDocumentoVenta.FechaElimino;
                tipoDocumentoVentaToRemove.IdUsuarioElimino = tipoDocumentoVenta.IdUsuarioElimino;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TipoDocumentoVenta tipoDocumentoVenta)
        {
            var tipoDocumentoVentaToUpdate = this.GetTipoDocumentoVenta(tipoDocumentoVenta.Id);

            tipoDocumentoVentaToUpdate.Descripcion = tipoDocumentoVenta.Descripcion;
            tipoDocumentoVentaToUpdate.EsActivo = tipoDocumentoVenta.EsActivo;
            tipoDocumentoVentaToUpdate.Eliminado = tipoDocumentoVenta.Eliminado;

            this.context.TipoDocumentoVentas.Update(tipoDocumentoVentaToUpdate);
            this.context.SaveChanges();

            
        }
    }
}
