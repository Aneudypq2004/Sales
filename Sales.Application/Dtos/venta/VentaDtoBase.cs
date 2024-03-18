namespace Sales.Application.Dtos.venta
{
    public class VentaDtoBase:DtoBase
    {
        public string? Numeroventa { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        

    }
}
