using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Repositories.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetAllAsync() =>
            await _context.Productos.Include(p => p.Productor).ToListAsync();
        public async Task<Producto?> GetByIdAsync(int id) =>
            await _context.Productos.Include(p => p.Productor)
                                    .FirstOrDefaultAsync(p => p.ProductoID == id);
        public async Task AddAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
            }
        }
    }
}
