namespace MercadoLocal.API.DTOs.Reseñas
{
    public class ReseñaReadDTO
    {
        public int ReseñaID { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
        public int ProductoID { get; set; }
    }
}
