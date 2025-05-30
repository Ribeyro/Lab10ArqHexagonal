using Lab10.Application.DTOs.Users;
using Lab10.Application.Services.UserServices;
using Lab10.Domain.Interfaces;
using Lab10.Domain.Repositories;

namespace Lab10.Application.Services.AuthServices;

public class AuthService:IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.FindByUsernameAsync(dto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Credenciales inválidas");

        var roles = user.UserRoles.Select(r => r.Role.RoleName).ToList();
        var token = _jwtService.GenerateToken(user, roles);

        return new LoginResponseDto
        {
            Token = token,
            Username = user.Username,
            Roles = roles
        };
    }
}