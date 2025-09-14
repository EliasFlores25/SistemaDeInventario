namespace MercadoLocal.API.DTOs.Reseñas
{
    public class ReseñaUpdateDTO
    {
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}
