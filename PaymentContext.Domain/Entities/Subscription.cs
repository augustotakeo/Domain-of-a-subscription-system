namespace PaymentContext.Domain.Entities;

public class Subscription {
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    private bool Active { get; set; }
    public List<Payment> Payments { get; set; } = null!;
}