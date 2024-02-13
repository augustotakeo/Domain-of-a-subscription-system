using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment {
    public Email Email { get; private set; }
    public string? TransactionCode { get; private set; }

    public PaypalPayment(Email email, decimal total, Name payer, Document document) : base(total, payer, document) {
        AddNotifications(Email = email);
    }

    public void UpdateTransactionCode(string transactionCode) {
        TransactionCode = transactionCode;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .Matches(TransactionCode, "^[0-9a-zA-Z]", "PaypalPayment.TransactionCode", "Invalid paypal transaction code")
        );
    }
}