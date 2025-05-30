namespace Lab10.Domain.Entities;

public partial class Roles
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}
