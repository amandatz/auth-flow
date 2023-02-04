using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.Core.RefreshToken;
using AuthFlow.Domain.Core.RefreshToken.ValueObjects;
using AuthFlow.Domain.Core.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AuthFlow.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AuthFlowDbContext _dbContext;

    public RefreshTokenRepository(AuthFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshToken?> GetByToken(string token)
    {
        return await _dbContext.RefreshTokens.SingleOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task Insert(RefreshToken refreshToken)
    {
        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(RefreshTokenId id)
    {
        var refreshToken = await _dbContext.RefreshTokens.FindAsync(id);

        if (refreshToken is null)
            return;

        _dbContext.RefreshTokens.Remove(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteByUserId(UserId userId)
    {
        var refreshTokens = await _dbContext.RefreshTokens.Where(rt => rt.UserId == userId).ToListAsync();
        _dbContext.RefreshTokens.RemoveRange(refreshTokens);
        await _dbContext.SaveChangesAsync();
    }
}