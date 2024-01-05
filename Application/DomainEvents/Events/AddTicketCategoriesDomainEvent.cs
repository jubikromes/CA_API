using Application.Models.Event;
using MediatR;
namespace Application.DomainEvents.Events;

public class AddTicketCategoriesDomainEvent : INotification
{
    public Guid EventId { get; set; }
    public IEnumerable<CreateTicketCategoryViewModel> CreateTicketCategoryViewModels { get; set; }
}

