using Microsoft.Extensions.Logging;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.core;
using Sales.Infrastructure.Exeption;
using Sales.Infrastructure.Interface;


namespace Sales.Infrastructure.Repositories
{
    public class NegocioRepocitory : BaseRepository<Negocio>, INegocioRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<NegocioRepocitory> logger;

        public NegocioRepocitory(SalesContext context, ILogger<NegocioRepocitory> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Negocio> GetEntities()
        {
            return base.GetEntities().Where(Negocio => !Negocio.Eliminado).ToList();
        }
        public override void Update(Negocio entity)
        {
            try
            {
                var NegocioToUpdate = this.GetEntity(entity.Id);
                NegocioToUpdate.UrlLogo = entity.UrlLogo;
                NegocioToUpdate.NombreLogo = entity.NombreLogo;
                NegocioToUpdate.NumeroDocumento = entity.NumeroDocumento;
                NegocioToUpdate.Nombre = entity.Nombre;
                NegocioToUpdate.Correo = entity.Correo;
                NegocioToUpdate.Direccion = entity.Direccion;
                NegocioToUpdate.Telefono = entity.Telefono;
                NegocioToUpdate.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                NegocioToUpdate.SimboloMoneda = entity.SimboloMoneda;
                NegocioToUpdate.FechaRegistro = entity.FechaRegistro;
                context.Negocio!.Update(NegocioToUpdate);
                this.context.SaveChanges();
            }
            catch (NegocioException exc)
            {

                throw new ConfigurationException(exc.Message);
            }
        }
            public override void Save(Negocio entity)
        {
            try
            {
                if (context.Negocio!.Any(negocios => negocios.Nombre == entity.Nombre))
                    throw new NegocioException("El Negocio se encuentra registrado");


                this.context.Negocio!.Add(entity);
                this.context.SaveChanges();
            }
            catch (NegocioException exc)
            {

                throw new ConfigurationException(exc.Message);
            }

        }
        public override void Remuve(Negocio entity)
        {
            try
            {
                var negocioToRemuve = this.GetEntity(entity.Id);
                negocioToRemuve.UrlLogo = entity.UrlLogo;
                negocioToRemuve.NombreLogo = entity.NombreLogo;
                negocioToRemuve.NumeroDocumento = entity.NumeroDocumento;
                negocioToRemuve.Nombre = entity.Nombre;
                negocioToRemuve.Correo = entity.Correo;
                negocioToRemuve.Direccion = entity.Direccion;
                negocioToRemuve.Telefono = entity.Telefono;
                negocioToRemuve.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                negocioToRemuve.SimboloMoneda = entity.SimboloMoneda;
                negocioToRemuve.FechaRegistro = entity.FechaRegistro;
                this.context.Negocio!.Update(negocioToRemuve);
                this.context.SaveChanges();
            }
            catch (NegocioException exc)
            {

                throw new ConfigurationException(exc.Message);
            }
        }

    }
    
}