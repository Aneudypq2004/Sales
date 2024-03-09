

using Sales.Domain.Core;

namespace Sales.Domain.Entities.ModuloVentas
{
    public class TipoDocumentoVenta : BaseEntity
    {
        public bool? EsActivo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaMod { get; set; }

        public int? IdUsuarioMod { get; set; }

        public int? IdUsuarioElimino { get; set; }

        public DateTime? FechaElimino { get; set; }

        public bool Eliminado { get; set; }

    }
}
