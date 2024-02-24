
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Inteface
{
    public interface IDetalleVentaRepository
    {
        void Create(DetalleVenta DetalleVenta);
        void Update(DetalleVenta DetalleVenta);
        void Remove(DetalleVenta DetalleVenta);

        List<DetalleVenta> GetDetalleVentas();

        DetalleVenta? GetDetalleVenta(int id);
    }
}
