﻿namespace MercadoLocal.API.DTOs.Productos
{
    public class ProductoCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? ImagenURL { get; set; }
        public int ProductorID { get; set; }
    }
}
