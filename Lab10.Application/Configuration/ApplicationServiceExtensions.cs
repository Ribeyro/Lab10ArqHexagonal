using Lab10.Application.Services;
using Lab10.Application.Services.AuthServices;
using Lab10.Application.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab10.Application.Configuration;


public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)

    {
        // Aquí puedes registrar tus servicios de aplicación
        
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}