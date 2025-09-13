﻿namespace MercadoLocal.API.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Reseña> Reseñas { get; set; }
    }
}
