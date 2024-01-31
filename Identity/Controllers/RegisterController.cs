using Identity.Application.Commands;
using Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Identity.Controllers;

[ApiController]
public class RegisterController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register-customer")]
    [AllowAnonymous]
    public async Task<Result> RegisterCustomer(CreateCustomerUserCommand model)
    {
       return await _mediator.Send(model);
    }

}
