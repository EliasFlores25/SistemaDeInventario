using MercadoLocal.API.Models;

namespace MercadoLocal.API.Repositories.Interfaces
{
    public interface IDetallePedidoRepository
    {
        Task<IEnumerable<DetallePedido>> GetAllAsync();
        Task<DetallePedido?> GetByIdAsync(int id);
        Task AddAsync(DetallePedido detalle);
        Task UpdateAsync(DetallePedido detalle);
        Task DeleteAsync(int id);
    }
}
