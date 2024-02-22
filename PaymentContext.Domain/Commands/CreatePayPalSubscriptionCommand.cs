using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand : ICommand {
    public string StudentFirstName { get; set; } = null!;
    public string StudentLastName { get; set; } = null!;
    public string StudentDocument { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
    public DateTime PaidDate { get; set; }
    public decimal PaymentTotal { get; set; }
    public string PayerFirstName { get; set; } = null!;
    public string PayerLastName { get; set; } = null!;
    public string PayerDocument { get; set; } = null!;
    public EDocumentType PayerDocumentType { get; set; }
    public string PayPalEmail { get; set; } = null!;
    public string? PayPalTransactionCode { get; set; }
}