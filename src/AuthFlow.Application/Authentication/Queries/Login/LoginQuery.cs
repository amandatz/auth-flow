using AuthFlow.Application.Authentication.Common;
using AuthFlow.Domain.Common.Result;
using MediatR;

namespace AuthFlow.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<Result<AuthenticationResult>>;
