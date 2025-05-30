namespace Lab10.Domain.Entities;

public partial class Users
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Responses> Responses { get; set; } = new List<Responses>();

    public virtual ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}
