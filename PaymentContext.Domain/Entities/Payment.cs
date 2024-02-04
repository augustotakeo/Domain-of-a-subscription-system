using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment(decimal total, decimal totalPaid, string payer, string document) : Entity {
    public string Number { get; private set; } = Guid.NewGuid().ToString().Replace("-", string.Empty)[..10];
    public DateTime PaidAt { get; private set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; private set; } = DateTime.UtcNow;
    public decimal Total { get; private set; } = total;
    public decimal TotalPaid { get; private set; } = totalPaid;
    public string Payer { get; private set; } = payer;
    public string Document { get; private set; } = document;
}