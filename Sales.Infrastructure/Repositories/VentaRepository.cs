using Microsoft.Extensions.Logging;
using Sales.Domain.Entities.ModuloVentas;
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

        public override bool Exists(Func<Venta, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Venta> GetEntities()
        { 
            return base.GetEntities().Where(v => v != null).ToList();
        }

        public override void Save(Venta entity)
        {
            try
            {
                if (context.Venta!.Any(v => v.NumeroVenta == entity.NumeroVenta))

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
                var ventaToRemove = this.GetEntity(entity.Id) ?? throw new VentaException("Esta venta no se puede eliminar porque no existe");

                this.context.Venta!.Update(entity);
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

        public List<VentaModel> GetVentasbyTipoDocumentoVenta(int IdTipoDocumentoVenta)
        {
            List<VentaModel> tipodocumentoventas = new();
            try
            {
                tipodocumentoventas = (from v in this.context.Venta 
                                       join tdv in this.context.TipoDocumentoVenta! 
                                       on v.IdTipoDocumentoVenta 
                                       equals tdv.Id 
                                       where v.IdTipoDocumentoVenta == tdv.Id select new VentaModel()
                                       {
                                            Id= v.Id,
                                            NumeroVenta = v.NumeroVenta,
                                            IdTipoDocumentoVenta = tdv.Id,
                                            NombreCliente = v.NombreCliente,
                                            SubTotal = v.SubTotal,
                                            Total = v.Total,
                                            ImpuestoTotal = v.ImpuestoTotal,
                                            FechaRegistro = v.FechaRegistro

                                       }
                    ).ToList();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error obteniendo las ventas por tipo de documento de venta", ex.ToString());
            }

            return tipodocumentoventas;
        }

        public List<VentaModel> GetVentasbyUsuario(int IdUsuario)
        {
            List<VentaModel> usuarios = new();

            // when we have the Usuario's entity integration we can uncomment 

            /*try
            {
                usuarios = (from v in this.context.Venta
                            join user in this.context.Usuario! on v.IdUsuario equals user.Id
                            where v.IdUsuario == IdUsuario
                            select new VentaModel()
                            {
                                Id = v.Id,
                                IdUsuario = user.Id,
                                NumeroVenta = v.NumeroVenta,
                                NombreCliente = v.NombreCliente,
                                ImpuestoTotal = v.ImpuestoTotal,
                                SubTotal = v.SubTotal,
                                Total = v.Total
                            }
                    ).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las ventas por el usuario", ex.ToString());
            }*/

            return usuarios;

        }

    }
}
