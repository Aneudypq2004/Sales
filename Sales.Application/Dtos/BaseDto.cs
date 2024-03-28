namespace Sales.Application.Dtos
{
    public record BaseDto
    {
        public int UsuarioId { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
