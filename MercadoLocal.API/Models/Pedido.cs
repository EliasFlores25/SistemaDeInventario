namespace MercadoLocal.API.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<DetallePedido> Detalles { get; set; }
    }
}
