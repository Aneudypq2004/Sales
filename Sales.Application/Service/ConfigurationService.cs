using Sales.Application.Contracts;
using Sales.Application.Core;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;

namespace Sales.Application.Service
{
    public class ConfigurationService : BaseService<Configuracion>, IConfiguracionService
    {
        public ConfigurationService(SalesContext context) : base(context)
        {
        }
    }
}
