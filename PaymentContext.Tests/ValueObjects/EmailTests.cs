using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class EmailTests {

    private readonly Email _email = new("teste@gmail.com");

    [Fact]
    public void ShouldBeEqualWhenAddressIsEqual() {
        var email2 = new Email(_email.Address);
        var equals = _email.Equals(email2);
        Assert.True(equals);
    }

    [Fact]
    public void ShouldBeDifferentWhenAddressIsDifferent() {
        var email2 = new Email("teste2@gmail.com");
        var equals = _email.Equals(email2);
        Assert.False(equals);
    }

    [Fact]
    public void ShouldBeDifferentWhenObjectIsNull() {
        var equals = _email.Equals(null);
        Assert.False(equals);
    }

    [Fact]
    public void ShouldBeDifferentWhenObjectIsNotAnEmail() {
        var document = new Document("12345678901", Domain.Enums.EDocumentType.CNPJ);
        var equals = _email.Equals(document);
        Assert.False(equals);
    }

}

