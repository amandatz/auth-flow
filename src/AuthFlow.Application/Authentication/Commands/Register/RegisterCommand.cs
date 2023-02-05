using AuthFlow.Domain.Common.Result;
using MediatR;

namespace AuthFlow.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PasswordConfirmation) : IRequest<Result>;
