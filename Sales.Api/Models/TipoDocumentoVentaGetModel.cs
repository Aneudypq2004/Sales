namespace Sales.Api.Models
{
    public class TipoDocumentoVentaGetModel
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
