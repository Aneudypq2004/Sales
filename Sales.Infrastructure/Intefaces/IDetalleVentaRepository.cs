
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Inteface
{
    public interface IDetalleVentaRepository
    {
        void Create(DetalleVenta tipoDocumentoVenta);
        void Update(DetalleVenta tipoDocumentoVenta);
        void Remove(DetalleVenta tipoDocumentoVenta);

        List<DetalleVenta> GetDetalleVentas();

        DetalleVenta GetDetalleVenta(int id);
    }
}
