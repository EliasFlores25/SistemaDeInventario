using MercadoLocal.API.Models;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReseñasController : ControllerBase
    {
        private readonly IReseñaService _reseñaService;
        public ReseñasController(IReseñaService reseñaService)
        {
            _reseñaService = reseñaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reseñas = await _reseñaService.GetAllAsync();
            return Ok(reseñas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reseña = await _reseñaService.GetByIdAsync(id);
            if (reseña == null) return NotFound();
            return Ok(reseña);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Reseña reseña)
        {
            var created = await _reseñaService.CreateAsync(reseña);
            return CreatedAtAction(nameof(GetById), new { id = created.ReseñaID }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reseña reseña)
        {
            var updated = await _reseñaService.UpdateAsync(id, reseña);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reseñaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
