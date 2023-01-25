using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthFlow.Application.Contracts.Authentication;
using MediatR;
using AuthFlow.Domain.Common.Result;
using AuthFlow.Application.Authentication.Commands.Register;
using AuthFlow.Application.Authentication.Queries.Login;
using AuthFlow.Application.Authentication.Commands.Refresh;
using AuthFlow.Application.Authentication.Commands.Logout;
using MapsterMapper;

namespace AuthFlow.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public sealed class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(NoContent, Problem);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        var command = _mapper.Map<RefreshCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpDelete("[action]")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        var command = _mapper.Map<LogoutCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(NoContent, Problem);
    }
}
