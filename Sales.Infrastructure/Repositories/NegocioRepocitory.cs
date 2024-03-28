
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.core;
using Sales.Infrastructure.Exeption;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Services;


namespace Sales.Infrastructure.Repositories
{
    public class NegocioRepocitory : BaseRepository<Negocio>, INegocioRepository
    {
        private readonly SalesContext context;
        private readonly LoggerService<NegocioRepocitory> logger;

        public NegocioRepocitory(SalesContext context, LoggerService<NegocioRepocitory> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override Negocio GetEntity(int Id)
        {
            return context.Negocio!.Find(Id)!;
        }
        public override List<Negocio> GetEntities()
        {
            try
            {
                return context.Negocio!.ToList();
            }
            catch (Exception)
            {

                throw new NegocioException("no se pudo obtener el negocio");
            }
        }
        public Negocio? GetNegocioByEmail(string Email) 
        {
            try
            {
                return context.Negocio!.FirstOrDefault(n => n.Correo!.Equals(Email));
            }
            catch (Exception)
            {

                throw new NegocioException("no se pudo encontrar el correo de el negocio");
            }
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