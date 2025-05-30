namespace Lab10.Domain.Repositories;

public interface IUnitOfWork
{
    
    // Agrega más repositorios
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    Task<int> SaveChangesAsync();
}