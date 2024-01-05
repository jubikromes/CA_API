using Application.Entities;

namespace Application.Entities.Event;

public class TicketCategory : BaseEntity
{
    public string Name { get; set; } // or ticketType
    public string Description { get; set; }
    public decimal Discount { get; set; }
    public decimal Amount { get; set; }
    public int NoOfTickets { get; set; }
    public int? UpperSeatRange { get; set; }
    public int? LowerSeatRange { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
}
