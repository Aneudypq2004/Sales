

using Sales.Domain.Core;

namespace Sales.Domain.Entities.negocio
{
    internal class Negocio: BaseEntity
    {
        public string? UrlLogo { get; set; }
        public string? NombreLogo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre {  get; set; }
        public string? Correo { get; set; }
        public string? Direccion {  get; set; }
        public string? Telefono { get; set; }
        public decimal? PorcentajeImpuesto { get; set; }
        public string? SimboloMoneda { get; set; }
    }
}
