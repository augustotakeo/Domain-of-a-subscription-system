using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject {
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    
    public Document(string number, EDocumentType type) {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Valid(), "Documente.Number", "Invalid should have 11 or 14 digits"));
    }

    private bool Valid() {
        if(string.IsNullOrEmpty(Number))
            return false;

        if(!Number.All(char.IsDigit))
            return false;

        if(Type == EDocumentType.CPF)
            return Number.Length == 11;

        if(Type == EDocumentType.CNPJ)
            return Number.Length == 14;

        return false;
    }
}