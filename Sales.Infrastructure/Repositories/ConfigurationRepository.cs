using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class ConfigurationRepository : BaseRepository<Configuracion>, IConfigurationRepository
    {
        private readonly SalesContext context;

        public ConfigurationRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public override Configuracion? GetEntity (int Id)
        {
            try
            {
                return context.Configuracion!.Find(Id);
            }
            catch (Exception exc)
            {
                throw new ConfigurationException(exc.Message);
            }
        }

        public override List<Configuracion> GetEntities()
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


        public override void Save(Configuracion configuration)
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

        public override void Remove(Configuracion RemoveConfiguracion)
        {
            try
            {
                var configuration = GetEntity(RemoveConfiguracion.Id) ??
                    throw new ConfigurationException("La configuracion para eliminar  no existe");

                context.Configuracion!.Remove(configuration);

                context.SaveChangesAsync();
            }
            catch (Exception exc)
            {

                throw new ConfigurationException(exc.Message);
            }
        }

        public override void Update(Configuracion UpdateConfiguracion)
        {
            try
            {
                var configuration = GetEntity(UpdateConfiguracion.Id) ??
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
