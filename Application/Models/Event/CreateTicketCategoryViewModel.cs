namespace Application.Models.Event;

public class CreateTicketCategoryViewModel
{
    public string Name { get; set; } // or ticketType
    public string Description { get; set; }
    public decimal Discount { get; set; }
    public decimal Amount { get; set; }
    public int NoOfTickets { get; set; }
    public int? UpperSeatRange { get; set; }
    public int? LowerSeatRange { get; set; }
}

