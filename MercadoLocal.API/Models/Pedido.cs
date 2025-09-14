namespace MercadoLocal.API.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.UtcNow;
        public string Estado { get; set; } = "Pendiente";

        // Relaciones
        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<DetallePedido>? Detalles { get; set; }
    }
}
