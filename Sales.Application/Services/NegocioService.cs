using Sales.Application.Contracts;
using Sales.Application.Core;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;

namespace Sales.Application.Services
{
    public class NegocioService : BaseService<Negocio>, INegocioServices
    {
        public NegocioService(SalesContext context) : base(context)
        {
            
        }
    }
}
