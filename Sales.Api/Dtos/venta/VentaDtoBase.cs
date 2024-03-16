namespace Sales.Api.Dtos.venta
{
    public class VentaDtoBase:DtoBase
    {

        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        

    }
}
