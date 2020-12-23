using System.Linq;
using Bank.Domain.CustomerContext.Entities;
using Bank.Domain.CustomerContext.Queries;
using Bank.Domain.CustomerContext.Repository;
using Bank.Infra.DataContext;
using Dapper;

namespace Bank.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly BankNetDataContext _context;

        public CustomerRepository(BankNetDataContext context)
        {
            _context = context;
        }
        
        public void Save(Customer customer, string addressId)
        {
            var query = @"INSERT INTO customer(id, firstname, lastname, email, password, document, accountnumber, 
                addressid) VALUES (@id, @firstname, @lastname, @email, @password, @document, @accountnumber, @addressid)";
            
            _context.Connection.Execute(query,
                new
                {
                    id = customer.Id,
                    firstname = customer.Name.FirstName,
                    lastname = customer.Name.LastName,
                    email = customer.Email.Address,
                    password = customer.Password,
                    document = customer.Document.Number,
                    accountnumber = customer.AccountNumber,
                    addressid = addressId
                });
        }

        public GetDocumentQueryResult CheckDocument(string document)
        {
            var query = "select document from customer where document = @document";
            var documentExists = _context
                .Connection
                .Query<GetDocumentQueryResult>(query, new {document = document}).FirstOrDefault();

           return documentExists;
        }

        public GetEmailQueryResult CheckEmail(string email)
        {
            var query = "SELECT email FROM customer where email = @email";
            var emailExists = _context
                .Connection
                .Query<GetEmailQueryResult>(query, new {Email = email}).FirstOrDefault();

            return emailExists;
        }
    }
}