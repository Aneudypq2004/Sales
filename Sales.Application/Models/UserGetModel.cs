﻿namespace Sales.Application.Models
{
    public class UserGetModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public int IdRol { get; set; }

    }
}