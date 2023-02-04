using AuthFlow.Application.Common.Interfaces.Persistence;
using MediatR;
using AuthFlow.Domain.Common.Result;
using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Domain.Core.Errors;
using AuthFlow.Domain.Core.Users;

namespace AuthFlow.Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(command.Email);
        if (user is not null)
            return Result.Failure(Errors.User.DuplicateEmail);

        var hashedPassword = _passwordHasher.HashPassword(command.Password);

        user = User.Create(
            firstName: command.FirstName,
            lastName: command.LastName,
            email: command.Email,
            password: hashedPassword);

        await _userRepository.Insert(user);

        return Result.Success();
    }
}
