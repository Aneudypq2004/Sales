
using Sales.Domain.Entities;

using Sales.Domain.Repository;

namespace Sales.Infrastructure.Inteface
{
    public interface IVentaRepository: IBaseRepository<Venta>
    {

       // List<VentaModel> GetVentasbyTipoDocumentoVenta(int IdTipoDocumentoVenta);

        //List<VentaModel> GetVentasByUsuario(int IdUsuario);

       // List<VentaModel> GetVentasByUsuarioCreacion(int IdUsuarioCreacion);
    }
}
