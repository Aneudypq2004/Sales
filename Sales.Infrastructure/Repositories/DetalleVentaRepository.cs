using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        public void Create(DetalleVenta tipoDocumentoVenta)
        {
            
        }

        public DetalleVenta GetDetalleVenta(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetalleVenta> GetDetalleVentas()
        {
            throw new NotImplementedException();
        }

        public void Remove(DetalleVenta tipoDocumentoVenta)
        {
            
        }

        public void Update(DetalleVenta tipoDocumentoVenta)
        {
            
        }
    }
}
