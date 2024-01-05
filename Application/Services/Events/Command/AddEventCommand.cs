using Application.Models;
using Application.Models.Event;
using MediatR;
using Shared.Models;
namespace Application.Services.Events.Command;

public class AddEventCommand : IRequest<Result>
{
    //event
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public string TimeOfEvent { get; set; }

    public bool Published { get; set; }

    public IEnumerable<CreateTicketCategoryViewModel> CreateTicketCategoryViewModels {  get; set; }
}
