using Application.DomainEvents.Events;
using Application.Interfaces.Repository;
using Application.Models;
using Application.Services.Events.Command;
using MediatR;
using Shared.Models;

namespace Application.Services.Events.CommandHandlers;

public class AddEventCommandHander(IUnitOfWork unitOfWork) : IRequestHandler<AddEventCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(AddEventCommand request, CancellationToken cancellationToken)
    {
        var @event = new Entities.Event.Event {
        
            Description = request.EventDescription,
            EventName = request.EventName,
            Published = request.Published,
            TimeOfEvent = request.TimeOfEvent,
        };

        _unitOfWork.Repository<Entities.Event.Event>().Insert(@event);


        @event.AddDomainEvent(new AddTicketCategoriesDomainEvent
        {
            EventId = @event.Id,
            CreateTicketCategoryViewModels = request.CreateTicketCategoryViewModels,
        });


        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}
