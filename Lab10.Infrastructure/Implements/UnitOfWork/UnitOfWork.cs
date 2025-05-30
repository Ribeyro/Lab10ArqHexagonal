using Lab10.Domain.Repositories;
using Lab10.Infrastructure.Persistence.Data;


namespace Lab10.Infrastructure.Implements.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepository Users { get; }
    public IRoleRepository Roles { get; }
    public UnitOfWork(
        ApplicationDbContext context,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _context = context;
        Users = userRepository;
        Roles = roleRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}