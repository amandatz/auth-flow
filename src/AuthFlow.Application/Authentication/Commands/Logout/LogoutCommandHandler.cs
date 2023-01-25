using AuthFlow.Application.Common.Interfaces.Persistence;
using MediatR;
using AuthFlow.Domain.Common.Result;

namespace AuthFlow.Application.Authentication.Commands.Logout;

internal sealed class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LogoutCommandHandler(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<Result> Handle(LogoutCommand command, CancellationToken cancellationToken)
    {
        var token = await _refreshTokenRepository.GetByToken(command.RefreshToken);
        if (token is null)
            throw new Exception("Invalid refresh token");

        var user = await _userRepository.GetById(token.UserId);
        if (user is null)
            throw new Exception("Invalid user");

        await _refreshTokenRepository.DeleteByUserId(user.Id);

        return Result.Success();
    }
}
