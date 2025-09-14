namespace MercadoLocal.API.DTOs.DetallesPedido
{
    public class DetallePedidoReadDTO
    {
        public int DetallePedidoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
    }
}
