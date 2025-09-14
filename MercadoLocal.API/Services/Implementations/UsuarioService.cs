using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;


namespace MercadoLocal.API.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            // Hash password before saving (ensure caller has plain password)
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.PasswordHash);
            await _usuarioRepository.AddAsync(usuario);
            return usuario;
        }
        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var existing = await _usuarioRepository.GetByIdAsync(usuario.UsuarioID);
            if (existing == null) return usuario;
            // Update allowed fields
            existing.Nombre = usuario.Nombre;
            existing.Email = usuario.Email;
            existing.Rol = usuario.Rol;
            await _usuarioRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
            return true;
        }
    }
}
