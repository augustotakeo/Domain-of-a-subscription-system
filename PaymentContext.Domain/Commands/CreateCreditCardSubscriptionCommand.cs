using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionCommand : ICommand {
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
    public string CreditCardNumer { get; private set; } = null!;
    public string CreditCardHolderFirstName { get; private set; } = null!;
    public string CreditCardHolderLastName { get; private set; } = null!;
}