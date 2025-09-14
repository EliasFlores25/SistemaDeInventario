namespace MercadoLocal.API.Models
{
    public class Productor
    {
        public int ProductorID { get; set; }
        public string NombreNegocio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

        // Relaciones
        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}
