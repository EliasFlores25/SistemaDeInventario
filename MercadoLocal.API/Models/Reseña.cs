namespace MercadoLocal.API.Models
{
    public class Reseña
    {
        public int ReseñaID { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
       
        // Relaciones
        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }
        public int ProductoID { get; set; }
        public Producto? Producto { get; set; }
    }
}
