using MercadoLocal.API.Models;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> CreateAsync(Pedido pedido);
        Task<Pedido?> UpdateAsync(int id, Pedido pedido);
        Task<bool> DeleteAsync(int id);
    }
}
