using MercadoLocal.API.Models;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IDetallePedidoService
    {
        Task<IEnumerable<DetallePedido>> GetAllAsync();
        Task<DetallePedido?> GetByIdAsync(int id);
        Task<DetallePedido> CreateAsync(DetallePedido detalle);
        Task<DetallePedido?> UpdateAsync(int id, DetallePedido detalle);
        Task<bool> DeleteAsync(int id);
    }
}
