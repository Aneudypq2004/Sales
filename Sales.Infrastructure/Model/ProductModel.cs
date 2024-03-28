

namespace Sales.Infrastructure.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set;}
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set;}
        public DateTime FechaRegistro { get; set; }
    }
}