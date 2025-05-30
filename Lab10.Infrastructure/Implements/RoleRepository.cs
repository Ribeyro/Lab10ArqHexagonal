using Lab10.Domain.Entities;
using Lab10.Domain.Repositories;
using Lab10.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Implements;

public class RoleRepository: GenericRepository<Roles>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string roleName)
    {
       return await _context.Set<Roles>().AnyAsync(r => r.RoleName == roleName);
    }
}