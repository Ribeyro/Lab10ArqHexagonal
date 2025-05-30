using Lab10.Application.DTOs.Roles;

namespace Lab10.Application.Services;

public interface IRoleService
{
    Task<RoleDto> CreateRoleAsync(CreateRoleDto dto);
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
}