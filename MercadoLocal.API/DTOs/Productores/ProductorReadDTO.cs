namespace MercadoLocal.API.DTOs.Productores
{
    public class ProductorReadDTO
    {
        public int ProductorID { get; set; }
        public string NombreNegocio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
    }
}
