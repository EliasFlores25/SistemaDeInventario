namespace MercadoLocal.API.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; } 
        public int Stock { get; set; }
        public string? ImagenURL { get; set; }

        // Relaciones
        public int ProductorID { get; set; }
        public Productor? Productor { get; set; }
        public ICollection<DetallePedido>? DetallesPedido { get; set; }
        public ICollection<Reseña>? Reseñas { get; set; }
    }
}
