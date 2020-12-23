using Bank.Domain.CustomerContext.Entities;
using Bank.Domain.CustomerContext.Repository;
using Bank.Infra.DataContext;
using Dapper;

namespace Bank.Infra.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BankNetDataContext _context;

        public AddressRepository(BankNetDataContext context)
        {
            _context = context;
        }
        public void Save(Address address)
        {
            var query = @"INSERT INTO address(id, street, number, complement, district, city, state, country, zipcode)
                VALUES (@id, @street, @number, @complement, @district, @city, @state, @country, @zipcode)";
            
            _context.Connection.Execute(query,
                new
                {
                    id = address.Id,
                    street = address.Street,
                    number = address.Number,
                    complement = address.Complement,
                    district = address.District,
                    city = address.City,
                    state = address.State,
                    country = address.Country,
                    zipcode = address.ZipCode
                });
        }
    }
}