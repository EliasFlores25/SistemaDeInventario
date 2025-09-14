using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProductoRepository _productoRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IProductoRepository productoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
        }
        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }
        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }
        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            // Business rule example: check stock for each detalle and decrement it
            if (pedido.Detalles != null)
            {
                foreach (var detalle in pedido.Detalles)
                {
                    var producto = await _productoRepository.GetByIdAsync(detalle.ProductoID);
                    if (producto == null) throw new KeyNotFoundException($"Producto {detalle.ProductoID} no encontrado.");
                    if (producto.Stock < detalle.Cantidad) throw new System.InvalidOperationException($"Stock insuficiente para producto {producto.ProductoID}.");
                    producto.Stock -= detalle.Cantidad;
                    await _productoRepository.UpdateAsync(producto);
                    // set precio unitario if not provided
                    detalle.PrecioUnitario = producto.Precio;
                }
            }
            await _pedidoRepository.AddAsync(pedido);
            return pedido;
        }
        public async Task<Pedido?> UpdateAsync(int id, Pedido pedido)
        {
            var existing = await _pedidoRepository.GetByIdAsync(id);
            if (existing == null) return null;
            // Only allow estado update for now
            existing.Estado = pedido.Estado;
            await _pedidoRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _pedidoRepository.DeleteAsync(id);
            return true;
        }
    }
}
