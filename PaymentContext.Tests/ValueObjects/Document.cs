using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public class DocumentTests {

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
}