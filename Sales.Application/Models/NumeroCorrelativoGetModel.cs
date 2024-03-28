namespace Sales.Application.Models
{
    public class NumeroCorrelativoGetModel
    {
        public int Id { get; set; }
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
