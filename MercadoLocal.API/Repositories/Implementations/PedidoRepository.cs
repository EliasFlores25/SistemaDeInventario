using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Repositories.Implementations
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pedido>> GetAllAsync() =>
            await _context.Pedidos.Include(p => p.Detalles).ToListAsync();
        public async Task<Pedido?> GetByIdAsync(int id) =>
            await _context.Pedidos.Include(p => p.Detalles)
                                  .FirstOrDefaultAsync(p => p.PedidoID == id);
        public async Task AddAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
        }
    }
}
