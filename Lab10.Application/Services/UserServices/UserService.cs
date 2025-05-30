using System.Security.Cryptography;
using System.Text;
using Lab10.Application.DTOs.Users;
using Lab10.Domain.Entities;
using Lab10.Domain.Repositories;

namespace Lab10.Application.Services.UserServices;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task RegisterUserAsync(RegisterUserDto dto)
    {
        // Verificar si existe usuario o email
        var exists = await _userRepository.ExistsByUsernameOrEmailAsync(dto.Username, dto.Email);
        if (exists)
            throw new Exception("El usuario o correo ya existe.");

        // Crear usuario
        var user = new Users
        {
            Username = dto.Username,
            PasswordHash = HashPassword(dto.Password),
            Email = dto.Email,
            UserRoles = new List<UserRoles>
            {
                new UserRoles
                {
                    RoleId = dto.RoleId
                }
            }
        };

        // Guardar usuario y su relación con el rol
        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllWithRolesAsync(); // lo veremos en el repositorio

        return users.Select(u => new UserDto
        {
            UserId = u.UserId,
            Username = u.Username,
            Email = u.Email ?? "",
            Roles = u.UserRoles.Select(ur => ur.Role.RoleName).ToList()
        });
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password); // Requiere paquete: BCrypt.Net-Next
    }
}