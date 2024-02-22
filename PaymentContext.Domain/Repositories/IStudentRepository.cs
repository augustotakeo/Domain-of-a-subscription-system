using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Repositories;

public interface IStudentRepository {
    Task<bool> EmailExists(Email email);
    Task<bool> DocumentExists(Document document);
    Task CreateStudent(Student student);
}