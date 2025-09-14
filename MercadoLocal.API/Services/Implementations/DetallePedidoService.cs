using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly IDetallePedidoRepository _detalleRepository;
        public DetallePedidoService(IDetallePedidoRepository detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }
        public async Task<IEnumerable<DetallePedido>> GetAllAsync()
        {
            return await _detalleRepository.GetAllAsync();
        }
        public async Task<DetallePedido?> GetByIdAsync(int id)
        {
            return await _detalleRepository.GetByIdAsync(id);
        }
        public async Task<DetallePedido> CreateAsync(DetallePedido detalle)
        {
            await _detalleRepository.AddAsync(detalle);
            return detalle;
        }
        public async Task<DetallePedido?> UpdateAsync(int id, DetallePedido detalle)
        {
            var existing = await _detalleRepository.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Cantidad = detalle.Cantidad;
            existing.PrecioUnitario = detalle.PrecioUnitario;
            await _detalleRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _detalleRepository.DeleteAsync(id);
            return true;
        }
    }
