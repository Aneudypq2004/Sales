
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.core;
using Sales.Infrastructure.Exeption;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Services;


namespace Sales.Infrastructure.Repositories
{
    public class NumeroCorrelativoRepository : BaseRepository<NumeroCorrelativo>, INumeroCorrelativoRepository
    {
        private readonly SalesContext context;
        private readonly LoggerService<NumeroCorrelativoRepository> logger;

        public NumeroCorrelativoRepository(SalesContext context, LoggerService<NumeroCorrelativo> logger):base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        
        public override void Save(NumeroCorrelativo entity)
        {
            try
            {
                if (context.NumeroCorrelativo!.Any(NumeroCorrelativo => NumeroCorrelativo.UltimoNumero == entity.UltimoNumero))
                    throw new NegocioException("El Negocio se encuentra registrado");
                this.context.NumeroCorrelativo!.Add(entity);
                this.context.SaveChanges();
            }
            catch (NumeroCorrelativoException exc)
            {

                throw new ConfigurationException(exc.Message);
            }
         }
        public override List<NumeroCorrelativo> GetEntities()
        {
            return context.NumeroCorrelativo!.ToList();
        }
        public override NumeroCorrelativo GetEntity(int Id)
        {
            return context.NumeroCorrelativo!.Find((short)Id)!;
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
                this.context.NumeroCorrelativo!.Update(NumeroCorrelativoToUpdate);
                this.context.SaveChanges();
            }
            catch (NumeroCorrelativoException exc)
            {

                throw new ConfigurationException(exc.Message);
            }

        }
        public override void Remuve(NumeroCorrelativo entity)
        {
            try
            {
                var NumeroCorrelativoToRemuve = this.GetEntity(entity.Id);
                NumeroCorrelativoToRemuve.UltimoNumero = entity.UltimoNumero;
                NumeroCorrelativoToRemuve.CantidadDigitos = entity.CantidadDigitos;
                NumeroCorrelativoToRemuve.Gestion = entity.Gestion;
                NumeroCorrelativoToRemuve.FechaActualizacion = entity.FechaActualizacion;
                this.context.NumeroCorrelativo!.Update(NumeroCorrelativoToRemuve);
                this.context.SaveChanges();
            }
            catch (NumeroCorrelativoException exc)
            {

                throw new ConfigurationException(exc.Message);
            }
        }
    }
}
