
using Sales.Domain.Core;

namespace Sales.Domain.Entities.negocio
{
    internal class NumerroCorrelativo:BaseEntity
    {
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion {  get; set; }
        public DateTime? FechaActualizacion { get; set; }

    }
}
