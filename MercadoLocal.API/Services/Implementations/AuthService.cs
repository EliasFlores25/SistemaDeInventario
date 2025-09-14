using MercadoLocal.API.DTOs.Auth;
using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtHelper _jwtHelper;
        public AuthService(IUsuarioRepository usuarioRepository, JwtHelper jwtHelper)
        {
            _usuarioRepository = usuarioRepository;
            _jwtHelper = jwtHelper;
        }
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);
            if (usuario == null) return null;
            // Verify hashed password
            if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash)) return null;
            var token = _jwtHelper.GenerateToken(usuario);
            return new LoginResponseDTO
            {
                Token = token,
                Rol = usuario.Rol,
                Nombre = usuario.Nombre
            };
        }
        public async Task<bool> RegisterAsync(RegisterDTO request)
        {
            var existing = await _usuarioRepository.GetByEmailAsync(request.Email);
            if (existing != null) return false;
            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Rol = request.Rol
            };
            await _usuarioRepository.AddAsync(usuario);
            return true;
        }
    }
}
