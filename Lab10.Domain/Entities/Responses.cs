namespace Lab10.Domain.Entities;

public partial class Responses
{
    public int ResponseId { get; set; }

    public int TicketId { get; set; }

    public int ResponderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Users Responder { get; set; } = null!;

    public virtual Tickets Ticket { get; set; } = null!;
}
