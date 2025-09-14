using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Repositories.Implementations
{
    public class ProductorRepository : IProductorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Productor>> GetAllAsync() =>
            await _context.Productores.Include(p => p.Productos).ToListAsync();
        public async Task<Productor?> GetByIdAsync(int id) =>
            await _context.Productores.Include(p => p.Productos)
                                      .FirstOrDefaultAsync(p => p.ProductorID == id);
        public async Task AddAsync(Productor productor)
        {
            _context.Productores.Add(productor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Productor productor)
        {
            _context.Productores.Update(productor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var productor = await _context.Productores.FindAsync(id);
            if (productor != null)
            {
            }
        }
    }
}
