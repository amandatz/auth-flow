using AuthFlow.Domain.Core.User;
using AuthFlow.Domain.Core.User.ValueObjects;

namespace AuthFlow.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetById(UserId id);
    Task<User?> GetByEmail(string email);
    Task<User> Insert(User user);
}