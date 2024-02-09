using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject {
    public Address(string street, string number, string neighborhood, string zipCode, string city, string state, string country)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        City = city;
        State = state;
        Country = country;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerOrEqualsThan(street, 200, "Street", "Street should have no more than 200 characters")
            .IsGreaterOrEqualsThan(street, 3, "Street", "Street should have at least 3 characters")
            .IsLowerOrEqualsThan(neighborhood, 200, "Neighborhood", "Neighborhood should have no more than 200 characters")
            .IsGreaterOrEqualsThan(neighborhood, 3, "Neighborhood", "Neighborhood should have more than 3 characters")
            .AreEquals(ZipCode, 8, "Zip Code", "Zip Code should have 8 characters")
            .IsLowerOrEqualsThan(city, 200, "City", "City should have no more than 200 characters")
            .IsGreaterOrEqualsThan(city, 3, "City", "City should have at least 3 characters")
            .IsLowerOrEqualsThan(state, 200, "State", "State should have no more than 200 characters")
            .IsGreaterOrEqualsThan(state, 3, "State", "State should have at least 3 characters")
            .IsLowerOrEqualsThan(country, 200, "Country", "Country should have no more than 200 characters")
            .IsGreaterOrEqualsThan(country, 3, "Country", "Country should have at least 3 characters")
            .Matches(Number, "^[0-9]", "Number")
        );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }    
    public string State { get; private set; }
    public string Country { get; private set; }
}