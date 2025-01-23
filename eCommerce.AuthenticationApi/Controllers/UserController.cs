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
        [FromServices] CreateUserService createUserService,
        [FromServices] PubUserCreatedService pubUserCreatedService)
    {
        var result = await createUserService.Execute(request);
        await pubUserCreatedService.Execute(result);
        return Created(string.Empty, new { UserId = result.Id });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllUsersService getAllUsersService)
    {
        var result = await getAllUsersService.Execute();
        return Ok(result);
    }
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate(
        [FromBody] AuthRequest body,
        [FromServices] AuthenticateService authService)
    {
        var token = await authService.Execute(body);
        return Ok(token);
    }
}
