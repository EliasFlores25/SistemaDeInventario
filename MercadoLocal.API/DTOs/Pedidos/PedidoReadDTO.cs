namespace MercadoLocal.API.DTOs.Pedidos
{
    public class PedidoReadDTO
    {
        public int PedidoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
    }
}
