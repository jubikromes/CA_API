namespace Application.Entities.Event;

public class EventAgent : BaseEntity
{
    public int NoOfTicketsAssigned { get; set; }
    public Guid? AgentId { get; set; }
    public Guid? EventId { get; set; }
    public bool IsPrimary { get; set; }
}
