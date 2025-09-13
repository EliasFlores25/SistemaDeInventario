using Microsoft.EntityFrameworkCore;
using MercadoLocal.API.Models;
using Microsoft.AspNetCore.Mvc;
using MercadoLocal.API.Data;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
    public ProductosController(ApplicationDbContext context) => _context = context;
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        => await _context.Productos.Include(p => p.Productor).ToListAsync();
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();
        return producto;
    }
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoID }, producto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        if (id != producto.ProductoID) return BadRequest();
        _context.Entry(producto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    }
}
