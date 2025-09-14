using MercadoLocal.API.Models;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IProductorService
    {
        Task<IEnumerable<Productor>> GetAllAsync();
        Task<Productor?> GetByIdAsync(int id);
        Task<Productor> CreateAsync(Productor productor);
        Task<Productor> UpdateAsync(Productor productor);
        Task<bool> DeleteAsync(int id);
    }
}
