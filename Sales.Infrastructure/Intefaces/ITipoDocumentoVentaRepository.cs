

using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Inteface
{
    public interface ITipoDocumentoVentaRepository
    {
        void Create(TipoDocumentoVenta tipoDocumentoVenta);
        void Update(TipoDocumentoVenta tipoDocumentoVenta);
        void Remove(TipoDocumentoVenta tipoDocumentoVenta);

        List<TipoDocumentoVenta> GetTipoDocumentoVentas();

        TipoDocumentoVenta GetTipoDocumentoVenta(int id);
    }
}
