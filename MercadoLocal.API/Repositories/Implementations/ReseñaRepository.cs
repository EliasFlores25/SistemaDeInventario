using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Repositories.Implementations
{
    public class ReseñaRepository : IReseñaRepository
    {
        private readonly ApplicationDbContext _context;
        public ReseñaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reseña>> GetAllAsync() =>
            await _context.Reseñas.Include(r => r.Producto).Include(r => r.Usuario).ToListAsync();
        public async Task<Reseña?> GetByIdAsync(int id) =>
            await _context.Reseñas.Include(r => r.Producto).Include(r => r.Usuario)
                                  .FirstOrDefaultAsync(r => r.ReseñaID == id);
        public async Task AddAsync(Reseña reseña)
        {
            _context.Reseñas.Add(reseña);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Reseña reseña)
        {
            _context.Reseñas.Update(reseña);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña != null)
            {
            }
        }
    }
}
