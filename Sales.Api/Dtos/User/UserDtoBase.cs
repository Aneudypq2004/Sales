namespace Sales.Api.Dtos.User
{
    public class UserDtoBase : BaseDto
    {
        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Clave { get; set; }

    }
}
