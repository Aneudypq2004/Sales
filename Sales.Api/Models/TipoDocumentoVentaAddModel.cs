namespace Sales.Api.Models
{
    public class TipoDocumentoVentaAddModel
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public decimal? Total { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
