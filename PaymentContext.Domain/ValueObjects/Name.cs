using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject {

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Notification>()
            .IsBetween(FirstName.Length, 3, 200, "Name.FirstName", "First name should be between 3 and 200 characters")
            .IsBetween(LastName.Length, 3, 200, "Name.LastName", "Last name should be between 3 and 200 characters"));
    }

    public override string ToString()
        => $"{FirstName} {LastName}";
}