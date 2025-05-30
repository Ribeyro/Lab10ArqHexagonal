using Lab10.Domain.Entities;

namespace Lab10.Domain.Interfaces;

public interface IJwtService
{
    string GenerateToken(Users user, List<string> roles);
}