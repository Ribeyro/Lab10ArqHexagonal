namespace Lab10.Application.DTOs.Users;

public class RegisterUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RoleId { get; set; } // ID del rol a asignar
}