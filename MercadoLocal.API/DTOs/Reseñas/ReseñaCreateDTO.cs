namespace MercadoLocal.API.DTOs.Reseñas
{
    public class ReseñaCreateDTO
    {
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
        public int ProductoID { get; set; }
    }
}
