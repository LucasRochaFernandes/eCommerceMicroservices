using eCommerce.AuthenticationApi.Communication.Requests;
using eCommerce.AuthenticationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.AuthenticationApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] UserRequest request,
        [FromServices] CreateUserService createUserService)
    {
        var result = await createUserService.Execute(request);
        return Created(string.Empty, new { UserId = result });
    }
}
