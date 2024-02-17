
using Sales.Domain.Entities;
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Inteface
{
    public interface IVentaRepository
    {
        void Create(Venta tipoDocumentoVenta);
        void Update(Venta tipoDocumentoVenta);
        void Remove(Venta tipoDocumentoVenta);

        List<Venta> GetVentas();

        Venta GetVenta(int id);
    }
}
