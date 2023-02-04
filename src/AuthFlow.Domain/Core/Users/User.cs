using AuthFlow.Domain.Common.Models;
using AuthFlow.Domain.Core.Users.ValueObjects;

namespace AuthFlow.Domain.Core.Users;

public sealed class User : AggregateRoot<UserId>
{
    #pragma warning disable CS8618
    private User() { }
    #pragma warning disable CS8618

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
            Email.Create(email),
            password);
    }
}