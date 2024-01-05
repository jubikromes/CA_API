using Application.Services.Events.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Events.Validators
{
    public class AddEventCommandValidator : AbstractValidator<AddEventCommand>
    {
        public AddEventCommandValidator()
        {
            RuleFor(p => p.EventName).NotEmpty().NotNull();
            RuleFor(p => p.EventDescription).NotEmpty().NotNull();
            RuleFor(p => p.TimeOfEvent).NotEmpty().NotNull();
        }
    }
}
