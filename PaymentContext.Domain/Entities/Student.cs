using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student(Name name, Document document, Email email) : Entity
{
    private readonly IList<Subscription> _subscriptions = [];

    public Name Name { get; private set; } = name;
    public Document Document { get; private set; } = document;
    public Email Email { get; private set; } = email;
    public IReadOnlyList<Subscription> Subscriptions { get => [.._subscriptions]; }
}