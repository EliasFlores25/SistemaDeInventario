using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesPedidosController : ControllerBase
    {
        public class DetallesPedidoController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            public DetallesPedidoController(ApplicationDbContext context) => _context = context;
            [HttpGet]
            public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedido()
            => await _context.DetallesPedidos.Include(p => p.Productor).ToListAsync();
            [HttpGet("{id}")]




        }
    }
}
