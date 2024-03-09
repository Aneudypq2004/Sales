namespace Sales.Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdUsuarioCreacion { get; set; }

    }
}
