using Bank.Domain.CustomerContext.Entities;
using Bank.Domain.CustomerContext.Queries;

namespace Bank.Domain.CustomerContext.Repository
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);

        GetDocumentQueryResult CheckDocument(string document);

        GetEmailQueryResult CheckEmail(string email);
    }
}