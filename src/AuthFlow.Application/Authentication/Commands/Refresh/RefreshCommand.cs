using AuthFlow.Application.Authentication.Common;
using AuthFlow.Domain.Common.Result;
using MediatR;

namespace AuthFlow.Application.Authentication.Commands.Refresh;

public record RefreshCommand(
    string RefreshToken) : IRequest<Result<AuthenticationResult>>;