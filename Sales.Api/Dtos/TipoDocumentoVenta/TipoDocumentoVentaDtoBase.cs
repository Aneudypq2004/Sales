namespace Sales.Api.Dtos.TipoDocumentoVenta
{
    public class TipoDocumentoVentaDtoBase : DtoBase
    {
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
    }
}
