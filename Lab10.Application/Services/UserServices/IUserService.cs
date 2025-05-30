using Lab10.Application.DTOs.Users;

namespace Lab10.Application.Services.UserServices;

public interface IUserService
{
    Task RegisterUserAsync(RegisterUserDto dto);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}