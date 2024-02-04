using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription(DateTime? expiresAt, bool active) : Entity
{
    private  readonly IList<Payment> _payments = [];
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; private set; } = expiresAt;
    public bool Active { get; private set; } = active;
    public IReadOnlyList<Payment> Payments { get => [.._payments]; }
}