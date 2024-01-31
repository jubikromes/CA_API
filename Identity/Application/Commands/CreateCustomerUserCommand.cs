using Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace Identity.Application.Commands;

public class CreateCustomerUserCommand : IRequest<Result>
{
    public string CountryCode { get; set; }
    public string PhoneCode { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}

public class CreateCustomerUserCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<CreateCustomerUserCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result> Handle(CreateCustomerUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            CountryCode = request.CountryCode,
            PhoneCode = request.PhoneCode,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.Email,
            // to be done later
            //EmailConfirmed = true,
            //PhoneNumberConfirmed = true,
        };

        var createdUserResult = await _userManager.CreateAsync(user, password: request.Password);

        if (!createdUserResult.Succeeded)
            return Result.Failure("Could nor create user.");

        var addUserToRoleResult = await _userManager.AddToRoleAsync(user, "Customer");

        if (!addUserToRoleResult.Succeeded)
            return Result.Failure("Could not add user to role.");

        return Result.Success("Successfully added user.");
    }
}
