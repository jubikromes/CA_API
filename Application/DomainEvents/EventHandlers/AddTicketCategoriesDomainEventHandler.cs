using Application.DomainEvents.Events;
using Application.Entities.Event;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.DomainEvents.EventHandlers;

public class AddTicketCategoriesDomainEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<AddTicketCategoriesDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task Handle(AddTicketCategoriesDomainEvent notification, CancellationToken cancellationToken)
    {
        var categoryList = notification.CreateTicketCategoryViewModels.Select(p => new TicketCategory
        {
            Description = p.Description,
            LowerSeatRange = p.LowerSeatRange,
            UpperSeatRange = p.UpperSeatRange,
            Discount = p.Discount,
            CreatedDateUtc = DateTime.UtcNow,
            Amount = p.Amount,
            EventId = notification.EventId,
            NoOfTickets = p.NoOfTickets,
            Name = p.Name,
        });

        _unitOfWork.Repository<TicketCategory>().InsertMany(categoryList);

        await _unitOfWork.CommitAsync();
    }
}
