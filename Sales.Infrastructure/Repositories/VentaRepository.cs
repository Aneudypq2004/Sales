using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<VentaRepository> logger;

        public VentaRepository(SalesContext context, ILogger<VentaRepository> logger) : base(context){ 
            
            this.context = context;
            this.logger = logger; 
        }

        public override List<Venta> GetEntities()
        { 
            return base.GetEntities()
                        .ToList();
        }

        public override void Save(Venta entity)
        {
            try
            {
                if (context.Venta!.Any(v => v.NumeroVenta == v.NumeroVenta))

                    throw new VentaException("Este numero de venta ya se encuentra registrado");

                this.context.Venta!.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Error creando la venta");
            }
        }

        public override void Remove(Venta entity)
        {
            try
            {
                var ventaToRemove = this.GetEntity(entity.Id) ?? throw new VentaException("Esta venta ya existe");

                this.context.Venta!.Remove(ventaToRemove);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Error eliminando esta la venta");
            }
        }

        public override void Update(Venta entity)
        {
            try
            {
                var ventaToUpdate = this.GetEntity(entity.Id)?? throw new 
                VentaException("Este tipo de Documento de Venta ya existe");

                ventaToUpdate.NumeroVenta = entity.NumeroVenta;
                ventaToUpdate!.NombreCliente = entity.NombreCliente;
                ventaToUpdate.CocumentoCliente = entity.CocumentoCliente;
                ventaToUpdate.SubTotal = entity.SubTotal;
                ventaToUpdate.ImpuestoTotal = entity.ImpuestoTotal;
                ventaToUpdate.Total = entity.Total;

                this.context.Venta!.Update(ventaToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception){
                this.logger.LogError("Error actualizando la venta");
            }
        }

        public List<Venta> GetVentasbyTipoDocumentoVenta(int IdTipoDocumentoVenta)
        {   

            return context.Venta!.Where(v => v.IdTipoDocumentoVenta.Equals(IdTipoDocumentoVenta)).ToList();
        }
    }
}
