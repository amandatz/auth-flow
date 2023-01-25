using AuthFlow.Domain.Common.Result;
using MediatR;

namespace AuthFlow.Application.Authentication.Commands.Logout;

public record LogoutCommand(
    string RefreshToken) : IRequest<Result>;