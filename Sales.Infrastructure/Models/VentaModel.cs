
namespace Sales.Domain.Entities.ModuloVentas
{
    public class VentaModel 
    {
        public int Id { get; set; }
        
        public string? NumeroVenta { get; set; }

        public int? IdUsuario { get; set; }
        public int ? IdTipoDocumentoVenta { get; set; }
        public string? NombreCliente { get; set; }

        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        public decimal? ImpuestoTotal { get; set; }

        public DateTime? FechaRegistro { get; set; }

    }
}
