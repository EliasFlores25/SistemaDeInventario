namespace MercadoLocal.API.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public int ProductorID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string ImagenURL { get; set; }
        public Productor Productor { get; set; }
        public ICollection<DetallePedido> DetallesPedidos { get; set; }
        public ICollection<Reseña> Reseñas { get; set; }
    }
}
