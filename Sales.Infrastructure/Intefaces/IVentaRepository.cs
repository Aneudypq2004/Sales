
using Sales.Domain.Entities;
using Sales.Domain.Entities.ModuloVentas;

namespace Sales.Infrastructure.Inteface
{
    public interface IVentaRepository
    {
        void Create(Venta venta);
        void Update(Venta venta);
        void Remove(Venta venta);

        List<Venta> GetVentas();

        Venta? GetVenta(int id);
    }
}
