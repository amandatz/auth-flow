using AuthFlow.Application.Authentication.Common;
using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.Common.Result;
using MediatR;
using AuthFlow.Domain.Core.Errors;

namespace AuthFlow.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IAuthenticator authenticator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(query.Email);
        if (user is null)
            return Result.Failure<AuthenticationResult>(Errors.Authentication.InvalidCredentials);

        if (!_passwordHasher.VerifyPassword(query.Password, user.Password))
            return Result.Failure<AuthenticationResult>(Errors.Authentication.InvalidCredentials);

        var authResult = await _authenticator.Authenticate(user);

        return Result.Success(authResult);
    }
}
