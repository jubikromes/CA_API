using Application.DomainEvents.Events;
using Application.Entities;
using Application.Models.Event;

namespace Application.Entities.Event;

public class Event : BaseEntity
{
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? TimeOfEvent { get; set; }
    public List<TicketCategory> TicketCategories { get; set; }
    public Venue Venue { get; set; }
    public Guid? VenueId { get; set; }
    public bool Published { get; set; }
    public void AddTicketCategories(IEnumerable<CreateTicketCategoryViewModel> CreateTicketCategoryViewModels)
    {
        AddDomainEvent(new AddTicketCategoriesDomainEvent { CreateTicketCategoryViewModels = CreateTicketCategoryViewModels });
    }
}
