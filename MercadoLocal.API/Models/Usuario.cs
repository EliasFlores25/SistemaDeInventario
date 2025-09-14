namespace MercadoLocal.API.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol { get; set; } = "Consumidor";
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relaciones
        public ICollection<Pedido>? Pedidos { get; set; }
        public ICollection<Reseña>? Reseñas { get; set; }
    }
}
