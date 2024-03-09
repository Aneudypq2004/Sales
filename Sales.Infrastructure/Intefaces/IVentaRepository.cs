using Sales.Domain.Entities;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Inteface
{
    public interface IVentaRepository: IBaseRepository<Venta>
    {

       List<Venta> GetVentasbyTipoDocumentoVenta(int IdTipoDocumentoVenta);

    }
}
