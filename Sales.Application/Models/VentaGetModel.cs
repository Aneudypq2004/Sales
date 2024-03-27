
namespace Sales.Application.Models
{
    public class VentaGetModel
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoDocumentoVenta { get; set; }
        public string? Numeroventa { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioCreacion { get; set; }
    }
}
