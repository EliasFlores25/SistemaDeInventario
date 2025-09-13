namespace MercadoLocal.API.Models
{
    public class Productor
    {
        public int ProductorID { get; set; }
        public int UsuarioID { get; set; }
        public string NombreNegocio { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
