using Lab10.Domain.Entities;
using Lab10.Domain.Repositories;
using Lab10.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Implements;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Users user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistsByUsernameOrEmailAsync(string username, string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Username == username || u.Email == email);
    }
    public async Task<List<Users>> GetAllWithRolesAsync()
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .ToListAsync();
    }
    
    public async Task<Users?> FindByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Username == username);
    }


}