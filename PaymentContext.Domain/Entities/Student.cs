using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student(string firstName, string lastName, string document, string email) : Entity
{
    private readonly IList<Subscription> _subscriptions = [];

    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string Document { get; private set; } = document;
    public string Email { get; private set; } = email;
    public IReadOnlyList<Subscription> Subscriptions { get => [.._subscriptions]; }
}