namespace MercadoLocal.API.DTOs.Productos
{
    public class ProductoReadDTO
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string ProductorNombre { get; set; } = string.Empty;
    }
}
