using MercadoLocal.API.DTOs.Auth;
using MercadoLocal.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLocal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var response = await _authService.LoginAsync(request);
            if (response == null) return Unauthorized("Credenciales inválidas");
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            var success = await _authService.RegisterAsync(request);
            if (!success) return BadRequest("El email ya está en uso");
            return Ok("Usuario registrado exitosamente");
        }
    }
}
