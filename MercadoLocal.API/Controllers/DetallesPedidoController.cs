using MercadoLocal.API.Models;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly IDetallePedidoService _detallePedidoService;
        public DetallesPedidoController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalles = await _detallePedidoService.GetAllAsync();
            return Ok(detalles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detalle = await _detallePedidoService.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return Ok(detalle);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DetallePedido detalle)
        {
            var created = await _detallePedidoService.CreateAsync(detalle);
            return CreatedAtAction(nameof(GetById), new { id = created.DetallePedidoID }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetallePedido detalle)
        {
            var updated = await _detallePedidoService.UpdateAsync(id, detalle);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _detallePedidoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
