using Lab10.Application.DTOs.Roles;
using Lab10.Domain.Entities;
using Lab10.Domain.Repositories;

namespace Lab10.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto dto)
    {
        // Verificar si el rol ya existe
        var exists = await _roleRepository.ExistsByNameAsync(dto.RoleName);
        if (exists)
            throw new InvalidOperationException("El rol ya existe.");

        // Crear la entidad
        var role = new Roles() { RoleName = dto.RoleName };

        // Guardar en base de datos
        await _roleRepository.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();

        // Retornar DTO
        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName
        };
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();

        return roles.Select(role => new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName
        });
    }
}