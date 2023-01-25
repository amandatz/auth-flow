using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Application.Services.Common;
using AuthFlow.Domain.User;

namespace AuthFlow.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRefreshTokenValidator _refreshTokenValidator;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthenticationService(
        IAuthenticator authenticator,
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IRefreshTokenValidator refreshTokenValidator)
    {
        _authenticator = authenticator;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _refreshTokenValidator = refreshTokenValidator;
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user is null)
            throw new Exception("Invalid credentials");

        if(!_passwordHasher.VerifyPassword(password, user.Password))
            throw new Exception("Invalid credentials");

        return await _authenticator.Authenticate(user);
    }

    public async Task<AuthenticationResult> RefreshAsync(string refreshToken)
    {
        var isRefreshTokenValid = _refreshTokenValidator.Validate(refreshToken);
        if (!isRefreshTokenValid)
            throw new Exception("Invalid refresh token");

        var token = await _refreshTokenRepository.GetByToken(refreshToken);
        if (token is null)
            throw new Exception("Invalid refresh token");

        var user = await _userRepository.GetById(token.UserId);
        if (user is null)
            throw new Exception("Invalid user");

        await _refreshTokenRepository.Delete(token.Id);

        return await _authenticator.Authenticate(user);
    }

    public async Task LogoutAsync(string refreshToken)
    {
        var token = await _refreshTokenRepository.GetByToken(refreshToken);
        if (token is null)
            throw new Exception("Invalid refresh token");

        var user = await _userRepository.GetById(token.UserId);
        if (user is null)
            throw new Exception("Invalid user");

        await _refreshTokenRepository.DeleteByUserId(user.Id);
    }
}