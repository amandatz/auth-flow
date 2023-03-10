using AuthFlow.Application.Common.Interfaces.Persistence;
using MediatR;
using AuthFlow.Domain.Common.Result;
using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Application.Authentication.Common;
using AuthFlow.Domain.Core.Errors;

namespace AuthFlow.Application.Authentication.Commands.Refresh;

internal sealed class RefreshCommandHandler : IRequestHandler<RefreshCommand, Result<AuthenticationResult>>
{
    private readonly IAuthenticator _authenticator;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenValidator _refreshTokenValidator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RefreshCommandHandler(
        IUserRepository userRepository,
        IRefreshTokenValidator refreshTokenValidator,
        IRefreshTokenRepository refreshTokenRepository,
        IAuthenticator authenticator)
    {
        _userRepository = userRepository;
        _refreshTokenValidator = refreshTokenValidator;
        _refreshTokenRepository = refreshTokenRepository;
        _authenticator = authenticator;
    }

    public async Task<Result<AuthenticationResult>> Handle(RefreshCommand command, CancellationToken cancellationToken)
    {
        var isRefreshTokenValid = _refreshTokenValidator.Validate(command.RefreshToken);
        if (!isRefreshTokenValid)
            return Result.Failure<AuthenticationResult>(Errors.Authentication.InvalidRefreshToken);

        var token = await _refreshTokenRepository.GetByToken(command.RefreshToken);
        if (token is null)
            return Result.Failure<AuthenticationResult>(Errors.Authentication.InvalidRefreshToken);

        var user = await _userRepository.GetById(token.UserId);
        if (user is null)
            return Result.Failure<AuthenticationResult>(Errors.User.InvalidUser);

        await _refreshTokenRepository.Delete(token.Id);

        var authResult = await _authenticator.Authenticate(user);

        return Result.Success(authResult);
    }
}
