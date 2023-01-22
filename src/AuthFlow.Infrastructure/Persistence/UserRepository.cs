using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.User;
using AuthFlow.Domain.User.ValueObjects;

namespace AuthFlow.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public Task<User?> GetById(UserId id)
    {
        return Task.FromResult(_users.SingleOrDefault(u => u.Id.Equals(id)));
    }

    public Task<User?> GetByEmail(string email)
    {
        var x = _users.SingleOrDefault(u => u.Email.Value == email);
        return Task.FromResult(_users.SingleOrDefault(u => u.Email.Value == email));
    }

    public Task<User> Insert(User user)
    {
        _users.Add(user);
        return Task.FromResult(user);
    }
}