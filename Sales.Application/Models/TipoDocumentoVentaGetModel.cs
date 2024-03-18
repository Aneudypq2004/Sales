namespace Sales.Application.Models
{
    public class TipoDocumentoVentaGetModel
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Eliminado { get; set; }
        public int? IdUsuarioCreacion { get; set; }
    }
}
