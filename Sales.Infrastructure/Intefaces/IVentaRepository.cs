using Sales.Domain.Entities.ModuloVentas;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Inteface
{
    public interface IVentaRepository: IBaseRepository<Venta>
    {

       List<VentaModel> GetVentasbyTipoDocumentoVenta(int IdTipoDocumentoVenta);

        List<VentaModel> GetVentasbyUsuario(int IdUsuario);

    }
}
