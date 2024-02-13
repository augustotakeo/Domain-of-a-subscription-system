using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student: Entity
{
    private readonly IList<Subscription> _subscriptions = [];

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public IReadOnlyList<Subscription> Subscriptions { get => [.._subscriptions]; }

    public Student(Name name, Document document, Email email) {
        Name = name;
        Document = document;
        Email = email;
        
        AddNotifications(Name, Document, Email);
    }

    public void AddSubscription(Subscription subscription) {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(_subscriptions.Any(x => x.Active()), "Student.Subscriptions", "There's already an active subscription.")
            .IsTrue(subscription.Payments.Any(), "Student.Subscriptions", "Subscription should have payment."));
        AddNotifications(subscription);
        _subscriptions.Add(subscription);
    }
}