

using Sales.Domain.Entities;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Inteface;

namespace Sales.Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly SalesContext context;

        public VentaRepository(SalesContext context) { 
            this.context = context;
        }

        public void Create(Venta venta)
        {
            try
            {   if (context.Ventas.Any(venta => venta.NumeroVenta == venta.NumeroVenta))

                    /*throw new VentaException("Este numero de venta ya se encuentra registrado");*/



                this.context.Ventas.Add(venta);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venta? GetVenta(int id)
        {
            return this.context.Ventas!.Find(id);
        }

        public List<Venta> GetVentas()
        {
            return this.context.Ventas
                                .Where(venta => !venta.Eliminado)
                                .ToList();
        }

        public void Remove(Venta venta)
        {
            try{
                var ventaToRemove = this.GetVenta(venta.Id);// update dthe nullable

                ventaToRemove.Eliminado = true;
                ventaToRemove.FechaElimino = venta.FechaElimino;
                ventaToRemove.IdUsuarioElimino = venta.IdUsuarioElimino;

                this.context.Ventas.Update(ventaToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex){

                throw ex; //("Esta venta no existe");
            }
            
        }

        public void Update(Venta venta)
        {
            var ventaToUpdate = this.GetVenta(venta.Id);

            ventaToUpdate.NombreCliente = venta.NombreCliente;
            ventaToUpdate.CocumentoCliente = venta.CocumentoCliente;
            ventaToUpdate.SubTotal = venta.SubTotal;
            ventaToUpdate.ImpuestoTotal= venta.ImpuestoTotal;
            ventaToUpdate.Total = venta.Total;

            //ventaToUpdate.NumeroVenta = venta.NumeroVenta; // not sure if we need to update Numero.Venta

            this.context.Ventas.Update(ventaToUpdate);
            this.context.SaveChanges();
        }
    }
}
