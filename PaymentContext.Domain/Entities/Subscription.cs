using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private  readonly IList<Payment> _payments = [];
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
    public DateTime? ExpiresAt { get; private set; }
    public IReadOnlyList<Payment> Payments { get => [.._payments]; }

    public Subscription(DateTime? expiresAt) {
        CreatedAt = DateTime.Now;
        UpdateAt = DateTime.Now;
        ExpiresAt = expiresAt;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(ExpiresAt ?? DateTime.MaxValue, CreatedAt, "Subscription.ExpiresAt", "Expires date must be later than creation date")
            .IsGreaterOrEqualsThan(ExpiresAt ?? DateTime.MaxValue, UpdateAt, "Subscription.ExpiresAt", "Expires date must be later than update date")
        );
    }

    public bool Active() => (ExpiresAt ?? DateTime.MaxValue) > DateTime.Now;

    public void AddPayment(Payment payment) {
        UpdateAt = DateTime.Now;
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Active(), "Subscription.ExpiresAt", "Subscription is not active")
        );
        if(payment is null) {
            AddNotification("Subscription.Payments", "Payment is invalid");
        } 
        else {
            _payments.Add(payment);
            AddNotifications(payment);
        }
    }
}