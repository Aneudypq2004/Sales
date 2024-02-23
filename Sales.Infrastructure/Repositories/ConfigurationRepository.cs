using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly SalesContext context;

        public ConfigurationRepository(SalesContext context)
        {
            this.context = context;
        }

        public Configuracion? GetConfiguracionById(int IdConfiguracion)
        {
            try
            {
                return context.Configuracion!.Find(IdConfiguracion);
            }
            catch (Exception exc)
            {
                throw new ConfigurationException(exc.Message);
            }
        }

        public List<Configuracion> GetConfigurations()
        {
            try
            {
                return context.Configuracion!.ToList();
            }
            catch (Exception exc)
            {
                throw new ConfigurationException(exc.Message);
            }
        }


        public void Create(Configuracion configuration)
        {
            try
            {
                context.Configuracion!.Add(configuration);
                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {
                throw new ConfigurationException(exc.Message);
            }
        }  

        public void Remove(Configuracion RemoveConfiguracion)
        {
            try
            {
                var configuration = GetConfiguracionById(RemoveConfiguracion.Id) ??
                    throw new ConfigurationException("La configuracion para eliminar  no existe");

                context.Configuracion!.Remove(configuration);

                context.SaveChangesAsync();


            }
            catch (Exception exc)
            {

                throw new ConfigurationException(exc.Message);
            }
        }

        public void Update(Configuracion UpdateConfiguracion)
        {
            try
            {
                var configuration = GetConfiguracionById(UpdateConfiguracion.Id) ??
                    throw new ConfigurationException("La configuracion para actualizar no existe");

                configuration.Valor = UpdateConfiguracion.Valor;
                configuration.Recurso = UpdateConfiguracion.Recurso;
                configuration.Propiedad = UpdateConfiguracion.Propiedad;

                context.Configuracion!.Update(configuration);

                context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                throw new ConfigurationException(exc.Message);
            }
        }
    }
}
