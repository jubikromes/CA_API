using Identity.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Identity.Controllers;

public class RoleManagementController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("add-role")]
    [AllowAnonymous]
    public async Task<Result> AddRole(AddRoleCommand model)
    {
        return await _mediator.Send(model);
    }

    [HttpPost("add-permission-to-role")]
    [AllowAnonymous]
    public async Task<Result> AddPermissionsToRole(AddPermissionToRoleCommand model)
    {
        return await _mediator.Send(model);
    }
}