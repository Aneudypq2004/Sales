namespace Sales.Api.Dtos.Product
{
    public class ProductUpdateDto : DtoBase
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
    }
}
