namespace MercadoLocal.API.Models
{
    public class Reseña
    {
        public int ReseñaID { get; set; }
        public int ProductoID { get; set; }
        public int UsuarioID { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public Producto Producto { get; set; }
        public Usuario Usuario { get; set; }
    }
}
