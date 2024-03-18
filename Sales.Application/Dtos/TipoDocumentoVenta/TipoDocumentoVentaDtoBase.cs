namespace Sales.Application.Dtos.TipoDocumentoVenta
{
    public class TipoDocumentoVentaDtoBase : DtoBase
    {
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }

        public bool Eliminado { get; set; }
    }
}
