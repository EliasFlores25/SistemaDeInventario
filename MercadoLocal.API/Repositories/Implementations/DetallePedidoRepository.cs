using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Repositories.Implementations
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly ApplicationDbContext _context;
        public DetallePedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DetallePedido>> GetAllAsync() =>
            await _context.DetallesPedidos.Include(d => d.Producto).ToListAsync();
        public async Task<DetallePedido?> GetByIdAsync(int id) =>
            await _context.DetallesPedidos.Include(d => d.Producto)
                                          .FirstOrDefaultAsync(d => d.DetallePedidoID == id);
        public async Task AddAsync(DetallePedido detalle)
        {
            _context.DetallesPedidos.Add(detalle);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(DetallePedido detalle)
        {
            _context.DetallesPedidos.Update(detalle);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var detalle = await _context.DetallesPedidos.FindAsync(id);
            if (detalle != null)
            {
            }
        }
    }
}
