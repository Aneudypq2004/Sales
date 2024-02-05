﻿
namespace Sales.Domain.Entities.Production
{
    public class Producto
    {
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public double? Precio { get; set; }
    }
}
