using Lab10.Domain.Entities;
namespace Lab10.Domain.Repositories;

public interface IRoleRepository: IGenericRepository<Roles>
{
    Task<bool> ExistsByNameAsync(string roleName);
}