namespace Sales.Application.Dtos
{
    public class DtoBase
    {
        public int Id { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? IdUsuarioCreacion { get; set; }
    }
}
