﻿namespace Sales.Api.Dtos.Product
{
    public class ProductDtoBase : DtoBase
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategory { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
