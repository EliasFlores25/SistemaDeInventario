namespace MercadoLocal.API.DTOs.DetallesPedido
{
    public class DetallePedidoCreateDTO
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
    }
}
