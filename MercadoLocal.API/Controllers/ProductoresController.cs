using MercadoLocal.API.Models;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoresController : ControllerBase
    {
        private readonly IProductorService _productorService;
        public ProductoresController(IProductorService productorService)
        {
            _productorService = productorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productores = await _productorService.GetAllAsync();
            return Ok(productores);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productor = await _productorService.GetByIdAsync(id);
            if (productor == null) return NotFound();
            return Ok(productor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Productor productor)
        {
            var created = await _productorService.CreateAsync(productor);
            return CreatedAtAction(nameof(GetById), new { id = created.ProductorID }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Productor productor)
        {
            if (id != productor.ProductorID) return BadRequest();
            var updated = await _productorService.UpdateAsync(productor);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productorService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
