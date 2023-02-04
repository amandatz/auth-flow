using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.Core.Users;
using AuthFlow.Domain.Core.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AuthFlow.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthFlowDbContext _dbContext;

    public UserRepository(AuthFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetById(UserId id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToString() == email);
    }

    public async Task<User> Insert(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
}