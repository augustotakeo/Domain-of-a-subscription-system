using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject {
    public Document(string number, EDocumentType type) {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Valid(), "Documente.Number"));
    }
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

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