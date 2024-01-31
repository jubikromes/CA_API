using Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OpenIddictSetUp.Enums;
using Shared.Extensions;
using Shared.Models;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Commands;

public class AddPermissionToRoleCommand : IRequest<Result>
{
    public string RoleName { get; set; }
    public List<Permission> Permissions { get; set; }
}

public class AddPermissionToRoleCommandHandler(RoleManager<ApplicationRole> roleManager) : IRequestHandler<AddPermissionToRoleCommand, Result>
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task<Result> Handle(AddPermissionToRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByNameAsync(request.RoleName);

        if (role == null) return Result.Failure("Role does not exist.");

        var allPermissionValues = EnumExtensions.GetList<Permission>();

        var allRoleValues = request.Permissions.Select(p => Enum.GetName(p));

        if (allPermissionValues.Count == 0) return Result.Failure("Permissions do not exist.");

        var newRolePermissions = allPermissionValues
                                .Where(p => allRoleValues.Any(x => Enum.GetName(p.Key) == x))
                                .ToList();

        var removedRolePermissions = allPermissionValues
                                    .Where(p => !allRoleValues.Any(x => Enum.GetName(p.Key) == x))
                                    .ToList();

        var responseMessage = new StringBuilder();

        foreach (var permission in newRolePermissions)
        {
            var val = permission.Key;

            var type = Enum.GetName(typeof(Permission), val);
            
            if (string.IsNullOrEmpty(type)) continue;

            var claim = new Claim(nameof(Permission), val.ToString());
            var succeeded = await _roleManager.AddClaimAsync(role, claim);

            if (succeeded.Succeeded)
                responseMessage.Append($"Added permission {val}");
            else
                responseMessage.Append($"Could not add permission {val}");
        }
        foreach (var permission in removedRolePermissions)
        {
            var val = permission.Key;

            var type = Enum.GetName(typeof(Permission), val);

            if (string.IsNullOrEmpty(type)) continue;

            var claim = new Claim(nameof(Permission), val.ToString());
            await _roleManager.RemoveClaimAsync(role, claim);
        }

        return Result.Success();
    }
}
