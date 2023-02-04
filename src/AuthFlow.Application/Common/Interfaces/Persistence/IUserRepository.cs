using AuthFlow.Domain.Core.Users;
using AuthFlow.Domain.Core.Users.ValueObjects;

namespace AuthFlow.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetById(UserId id);
    Task<User?> GetByEmail(string email);
    Task<User> Insert(User user);
}