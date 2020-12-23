using Bank.Domain.CustomerContext.Entities;

namespace Bank.Domain.CustomerContext.Repository
{
    public interface IAddressRepository
    {
        void Save(Address address);
    }
}