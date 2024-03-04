

using Microsoft.Extensions.Logging;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.core;
using Sales.Infrastructure.Exeption;
using Sales.Infrastructure.Interface;

namespace Sales.Infrastructure.Repositories
{
    public class NumeroCorrelativoRepository : BaseRepository<NumeroCorrelativo>, INumeroCorrelativoRepository
    {
        private readonly SalesContext context;

        public ILogger<NumeroCorrelativoRepository> Logger { get; }

        public NumeroCorrelativoRepository(SalesContext context,ILogger<NumeroCorrelativoRepository>logger):base(context)
        {
            this.context = context;
            Logger = logger;
        }
        public override void Save(NumeroCorrelativo entity)
        {
            try
            {
                if (context.NumeroCorrelativo.Any(NumeroCorrelativo => NumeroCorrelativo.UltimoNumero == entity.UltimoNumero))
                    throw new NegocioException("El Negocio se encuentra registrado");
                this.context.NumeroCorrelativo.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ConfigurationException(ex.Message);
            }
        }

        public override List<NumeroCorrelativo> GetEntities()
        {
            return base.GetEntities().Where(NumeroCorrelativo => !NumeroCorrelativo.Eliminado).ToList();
        }

        public override void Update(NumeroCorrelativo entity)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetEntity(entity.Id);
                NumeroCorrelativoToUpdate.UltimoNumero = entity.UltimoNumero;
                NumeroCorrelativoToUpdate.CantidadDigitos = entity.CantidadDigitos;
                NumeroCorrelativoToUpdate.Gestion = entity.Gestion;
                NumeroCorrelativoToUpdate.FechaActualizacion = entity.FechaActualizacion;
                this.context.NumeroCorrelativo.Update(NumeroCorrelativoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ConfigurationException(ex.Message);
            }
        }
    }
}
