namespace Lab10.Domain.Entities;

public partial class Tickets
{
    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public virtual ICollection<Responses> Responses { get; set; } = new List<Responses>();

    public virtual Users User { get; set; } = null!;
}
