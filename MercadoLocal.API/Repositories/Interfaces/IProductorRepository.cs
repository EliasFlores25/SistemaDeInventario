using MercadoLocal.API.Models;

namespace MercadoLocal.API.Repositories.Interfaces
{
    public interface IProductorRepository
    {
        Task<IEnumerable<Productor>> GetAllAsync();
        Task<Productor?> GetByIdAsync(int id);
        Task AddAsync(Productor productor);
        Task UpdateAsync(Productor productor);
        Task DeleteAsync(int id);
    }
}
