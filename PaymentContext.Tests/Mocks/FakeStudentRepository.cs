using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public readonly IReadOnlyList<Document> Documents;
    public readonly IReadOnlyList<Email> Emails;

    public FakeStudentRepository() {
        Documents = [new Document("01234567891", Domain.Enums.EDocumentType.CPF)];
        Emails = [new Email("teste@gmail.com")];
    }

    public Task CreateStudent(Student student)
    {
        return Task.CompletedTask;
    }

    public Task<bool> DocumentExists(Document document)
    {
        var exist = Documents.Any(x => x.Equals(document));
        return Task.FromResult(exist);
    }

    public Task<bool> EmailExists(Email email)
    {
        var exist = Emails.Any(x => x.Equals(email));
        return Task.FromResult(exist);
    }
}