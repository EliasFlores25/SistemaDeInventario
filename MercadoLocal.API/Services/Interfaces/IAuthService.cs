using MercadoLocal.API.DTOs.Auth;

namespace MercadoLocal.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request);
        Task<bool> RegisterAsync(RegisterDTO request);
    }
}
