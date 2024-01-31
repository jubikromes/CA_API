
using Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace Identity.Application.Commands;

public class AddRoleCommand : IRequest<Result>
{
    public string RoleName { get; set; }
}

public class AddRoleCommandHandler(RoleManager<ApplicationRole> roleManager) : IRequestHandler<AddRoleCommand, Result>
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task<Result> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var roleName = request.RoleName?.ToLower();

        var role = new ApplicationRole(roleName);

        var response = await _roleManager.CreateAsync(role);

        if (!response.Succeeded)
            return Result.Success($"Could not Successfully add role {request.RoleName}");

        return Result.Success($"Successfully added role {request.RoleName}");
    }
}
