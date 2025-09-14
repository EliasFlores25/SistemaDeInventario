using MercadoLocal.API.Models;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> CreateAsync(Producto producto);
        Task<Producto?> UpdateAsync(int id, Producto producto);
        Task<bool> DeleteAsync(int id);
    }
}
