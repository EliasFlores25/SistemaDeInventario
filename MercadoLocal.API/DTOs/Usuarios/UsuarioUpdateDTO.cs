﻿namespace MercadoLocal.API.DTOs.Usuarios
{
    public class UsuarioUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
