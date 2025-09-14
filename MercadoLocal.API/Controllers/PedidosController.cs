using MercadoLocal.API.Models;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            return Ok(pedidos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            var created = await _pedidoService.CreateAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = created.PedidoID }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pedido pedido)
        {
            var updated = await _pedidoService.UpdateAsync(id, pedido);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pedidoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
