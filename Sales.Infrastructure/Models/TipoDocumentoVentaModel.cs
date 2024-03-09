namespace Sales.Domain.Entities.ModuloVentas
{
    public class TipoDocumentoVentaModel
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public bool? EsActivo { get; set; }

        public bool? Eliminado { get; set; }
    }
}
