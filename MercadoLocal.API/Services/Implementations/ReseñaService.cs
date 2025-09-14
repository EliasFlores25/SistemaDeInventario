using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class ReseñaService : IReseñaService
    {
        private readonly IReseñaRepository _reseñaRepository;
        public ReseñaService(IReseñaRepository reseñaRepository)
        {
            _reseñaRepository = reseñaRepository;
        }
        public async Task<IEnumerable<Reseña>> GetAllAsync()
        {
            return await _reseñaRepository.GetAllAsync();
        }
        public async Task<Reseña?> GetByIdAsync(int id)
        {
            return await _reseñaRepository.GetByIdAsync(id);
        }
        public async Task<Reseña> CreateAsync(Reseña reseña)
        {
            // Validate rating
            if (reseña.Calificacion < 1 || reseña.Calificacion > 5) throw new System.ArgumentOutOfRangeException("Calificacion debe estar entre 1 y 5");
            await _reseñaRepository.AddAsync(reseña);
            return reseña;
        }
        public async Task<Reseña?> UpdateAsync(int id, Reseña reseña)
        {
            var existing = await _reseñaRepository.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Calificacion = reseña.Calificacion;
            existing.Comentario = reseña.Comentario;
            await _reseñaRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _reseñaRepository.DeleteAsync(id);
            return true;
        }
    }
}
