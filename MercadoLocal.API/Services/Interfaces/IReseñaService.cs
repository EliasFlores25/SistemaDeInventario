using MercadoLocal.API.Models;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IReseñaService
    {
        Task<IEnumerable<Reseña>> GetAllAsync();
        Task<Reseña?> GetByIdAsync(int id);
        Task<Reseña> CreateAsync(Reseña reseña);
        Task<Reseña?> UpdateAsync(int id, Reseña reseña);
        Task<bool> DeleteAsync(int id);
    }
}
