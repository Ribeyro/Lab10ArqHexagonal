using Lab10.Domain.Entities;

namespace Lab10.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(Users user);
    Task<bool> ExistsByUsernameOrEmailAsync(string username, string email);
    Task<List<Users>> GetAllWithRolesAsync();
    Task<Users?> FindByUsernameAsync(string username);
}