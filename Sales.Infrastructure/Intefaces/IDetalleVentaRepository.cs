
using Sales.Domain.Entities.ModuloVentas;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Inteface
{
    public interface IDetalleVentaRepository: IBaseRepository <DetalleVenta>
    {
        //List<DetalleVentaModel> GetDetalleVentaModelByVenta(int IdVenta);
        //List<DetalleVentaModel> GetDetalleVentaModelByProducto(int IdProducto);
    }
}
