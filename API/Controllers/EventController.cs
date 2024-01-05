using Application.Services.Events.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("addevent")]
        public async Task<IActionResult> AddEvent(AddEventCommand command)
        {
            await   
                _mediator.Send(command);

            return Ok(command);
        }
      
    }
}
