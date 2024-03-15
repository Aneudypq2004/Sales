using Sales.Domain.Core;

namespace Sales.Domain.Entities.negocios
{
    public class NumeroCorrelativo
    {
        public int Id { get; set; }

        public int? UltimoNumero {  get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion {  get; set; }
        public DateTime? FechaActualizacion { get; set; }

    }
}
