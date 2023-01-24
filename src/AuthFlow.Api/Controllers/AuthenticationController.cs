using AuthFlow.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register()
    {
        await _authenticationService.RegisterAsync();
        return NoContent();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login()
    {
        await _authenticationService.LoginAsync();
        return NoContent();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Refresh()
    {
        await _authenticationService.RefreshAsync();
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Logout()
    {
        await _authenticationService.LogoutAsync();
        return NoContent();
    }
}