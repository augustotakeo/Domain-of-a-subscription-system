using Flunt.Validations;
using Flunt.Notifications;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity {
    public string Number { get; private set; }
    public DateTime PaidAt { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Name Payer { get; private set; }
    public Document Document { get; private set; }

    public Payment(decimal total, decimal totalPaid, Name payer, Document document) {
        Number = Guid.NewGuid().ToString().Replace("-", string.Empty)[..10];
        PaidAt = DateTime.UtcNow;
        ExpiresAt = DateTime.UtcNow;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Total, 0, "Payment.Total", "Total should be positive")
            .IsGreaterThan(TotalPaid, 0, "Payment.TotalPaid", "Total Paid should be positive"));
        AddNotifications(Document, Payer);
    }
}