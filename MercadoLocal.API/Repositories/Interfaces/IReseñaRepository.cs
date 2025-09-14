using MercadoLocal.API.Models;

namespace MercadoLocal.API.Repositories.Interfaces
{
    public interface IReseñaRepository
    {
        Task<IEnumerable<Reseña>> GetAllAsync();
        Task<Reseña?> GetByIdAsync(int id);
        Task AddAsync(Reseña reseña);
        Task UpdateAsync(Reseña reseña);
        Task DeleteAsync(int id);
    }
}
