using Sales.Domain.Entities.Usuario.Usuario;

namespace Sales.Infrastructure.Interfaces
{
    public interface IConfigurationRepository
    {
        void Create(Configuracion configuration);
        void Update(Configuracion UpdateConfiguracion);
        void Remove(Configuracion RemoveConfiguracion);
        List<Configuracion> GetConfigurations();
        Configuracion? GetConfiguracionById(int IdConfiguracion);
    }
}
