using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("register-customer")]
        public async Task RegisterCustomer(RegisterCustomerViewModel model)
        {
            await _userManager.CreateAsync(new ApplicationUser
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            }, password: model.Password);
        }
    }
}
