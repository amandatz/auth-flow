using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthFlow.Application.Contracts.Authentication;
using MediatR;
using AuthFlow.Domain.Common.Result;
using AuthFlow.Application.Authentication.Commands.Register;
using AuthFlow.Application.Authentication.Queries.Login;

namespace AuthFlow.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public sealed class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var authResult = await _mediator.Send(command);

        return authResult.Match(NoContent, Problem);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(new AuthenticationResponse(authResult.User.Id.Value, authResult.AccessToken, authResult.RefreshToken)),
            errors => Problem(errors));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        // var authResult = await _authenticationService.RefreshAsync(request.RefreshToken);
        // var response = new AuthenticationResponse(authResult.User.Id.Value, authResult.AccessToken, authResult.RefreshToken);
        // return Ok(response);
        return Ok();
    }

    [Authorize]
    [HttpDelete("[action]")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        // await _authenticationService.LogoutAsync(request.RefreshToken);
        return Ok();
    }
}
