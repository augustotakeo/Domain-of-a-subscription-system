using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class DocumentTests {

    private readonly Document _validDocument = new("12345678901", EDocumentType.CPF);

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("1234")]
    [InlineData("123456789d1234")]
    [InlineData("123456789012345")]
    public void ShouldReturnErrorWhenCNPJIsInvalid(string number) {
        var document = new Document(number, EDocumentType.CNPJ);
        Assert.False(document.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenCNPJIsValid() {
        var document = new Document("12345678901234", EDocumentType.CNPJ);
        Assert.True(document.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("1234")]
    [InlineData("123456789d1")]
    [InlineData("123456789012345")]
    public void ShouldReturnErrorWhenCPFIsInvalid(string number) {
        var document = new Document(number, EDocumentType.CPF);
        Assert.False(document.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenCPFIsValid() {
        var document = new Document("12345678901", EDocumentType.CPF);
        Assert.True(document.IsValid);
    }

    [Fact]
    public void ShoulBeEqualWhenAllPropertiesAreEqual() {
        var document = new Document(_validDocument.Number, _validDocument.Type);
        var equals = _validDocument.Equals(document);
        Assert.True(equals);
    }

    [Theory]
    [InlineData("12345678901", EDocumentType.CNPJ)]
    [InlineData("12345678902", EDocumentType.CPF)]
    [InlineData("12345678902", EDocumentType.CNPJ)]
    public void ShouldBeDifferentWhenAnyPropertyIsDifferent(string number, EDocumentType type) {
        var document = new Document(number, type);
        var equals = _validDocument.Equals(document);
        Assert.False(equals);
    }

    [Fact]
    public void ShoulBeDifferentWhenObjectIsNull() {
        var equals = _validDocument.Equals(null);
        Assert.False(equals);
    }

    [Fact]
    public void ShoulBeDifferentWhenObjectIsNotADocument() {
        var email = new Email("teste@gmail.com");
        var equals = _validDocument.Equals(email);
        Assert.False(equals);
    }
}