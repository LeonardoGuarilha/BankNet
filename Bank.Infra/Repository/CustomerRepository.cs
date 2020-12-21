using Bank.Domain.CustomerContext.Entities;
using Bank.Domain.CustomerContext.Queries;
using Bank.Domain.CustomerContext.Repository;

namespace Bank.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public GetDocumentQueryResult CheckDocument(string document)
        {
            throw new System.NotImplementedException();
        }

        public GetEmailQueryResult CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}