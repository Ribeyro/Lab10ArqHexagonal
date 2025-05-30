using Lab10.Application.DTOs.Users;

namespace Lab10.Application.Services.UserServices;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto dto);
}