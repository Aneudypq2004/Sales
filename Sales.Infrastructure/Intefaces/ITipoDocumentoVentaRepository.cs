


using Sales.Domain.Entities.ModuloVentas;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Inteface
{
    public interface ITipoDocumentoVentaRepository: IBaseRepository<TipoDocumentoVenta>

    {
        //List<TipoDocumentoVentaModel> GetTipoDocumentoVentaById(int Id);

    }
}
