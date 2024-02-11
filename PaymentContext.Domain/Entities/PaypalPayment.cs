using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment {
    public Email Email { get; private set; }
    public string TransactionCode { get; private set; }

    public PaypalPayment(Email email, decimal total, decimal totalPaid, Name payer, 
        Document document) : base(total, totalPaid, payer, document) {
            Email = email;
            
            AddNotifications(Email);
    }
}