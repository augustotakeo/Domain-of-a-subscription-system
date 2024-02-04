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
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }    
    public string State { get; private set; }
    public string Country { get; private set; }
}