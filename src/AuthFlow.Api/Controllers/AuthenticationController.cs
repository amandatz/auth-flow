using AuthFlow.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthFlow.Application.Contracts.Authentication;

namespace AuthFlow.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        await _authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var authResult = await _authenticationService.LoginAsync(request.Email, request.Password);
        var response = new AuthenticationResponse(authResult.User.Id.Value, authResult.AccessToken, authResult.RefreshToken);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        var authResult = await _authenticationService.RefreshAsync(request.RefreshToken);
        var response = new AuthenticationResponse(authResult.User.Id.Value, authResult.AccessToken, authResult.RefreshToken);
        return Ok(response);
    }

    [Authorize]
    [HttpDelete("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        await _authenticationService.LogoutAsync(request.RefreshToken);
        return Ok();
    }
}
