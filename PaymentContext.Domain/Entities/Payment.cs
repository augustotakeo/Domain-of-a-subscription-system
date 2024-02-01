namespace PaymentContext.Domain.Entities;

public abstract class Payment {
    public string Number { get; set; } = null!;
    public DateTime PaidAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Document { get; set; } = null!;
}