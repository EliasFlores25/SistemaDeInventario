using MercadoLocal.API.Data;
using MercadoLocal.API.Models;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            return Ok(productos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var created = await _productoService.CreateAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = created.ProductoID }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            var updated = await _productoService.UpdateAsync(id, producto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
