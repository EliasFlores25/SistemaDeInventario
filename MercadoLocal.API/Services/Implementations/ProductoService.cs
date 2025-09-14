using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductorRepository _productorRepository;
        public ProductoService(IProductoRepository productoRepository, IProductorRepository productorRepository)
        {
            _productoRepository = productoRepository;
            _productorRepository = productorRepository;
        }
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _productoRepository.GetAllAsync();
        }
        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }
        public async Task<Producto> CreateAsync(Producto producto)
        {
            // Optional: validate productor exists
            var productor = await _productorRepository.GetByIdAsync(producto.ProductorID);
            if (productor == null) throw new KeyNotFoundException("Productor no encontrado.");
            await _productoRepository.AddAsync(producto);
            return producto;
        }
        public async Task<Producto?> UpdateAsync(int id, Producto producto)
        {
            var existing = await _productoRepository.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Nombre = producto.Nombre;
            existing.Descripcion = producto.Descripcion;
            existing.Precio = producto.Precio;
            existing.Stock = producto.Stock;
            existing.ImagenURL = producto.ImagenURL;
            await _productoRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _productoRepository.DeleteAsync(id);
            return true;
        }
    }
}
