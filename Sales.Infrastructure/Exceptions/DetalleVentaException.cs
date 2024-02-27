using Sales.Infrastructure.Core;

namespace Sales.Infrastructure.Exceptions
{
    public class DetalleVentaException : BaseException
    {
        public DetalleVentaException(string message) : base(message)
        {
        }
    }
}

/*if (context.Ventas.Any(venta => venta.NumeroVenta == venta.NumeroVenta))*/