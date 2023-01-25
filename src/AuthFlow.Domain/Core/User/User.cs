using AuthFlow.Domain.Common.Models;
using AuthFlow.Domain.Core.User.ValueObjects;

namespace AuthFlow.Domain.Core.User;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId id, string firstName, string lastName, Email email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            Email.CreateNew(email),
            password);
    }
}