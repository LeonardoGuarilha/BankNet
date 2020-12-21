using Bank.Shared.Entities;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string complement, string district, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Street, "Street", "Rua não pode ser vazia")
                .IsNotNullOrEmpty(Number, "Number", "Número não pode ser vazio")
                .IsNotNullOrEmpty(Complement, "Complement", "Complemento não pode ser vazio")
                .IsNotNullOrEmpty(District, "District", "Bairro não pode ser vazio")
                .IsNotNullOrEmpty(City, "City", "Cidade não pode ser vazia")
                .IsNotNullOrEmpty(State, "State", "Estado não pode ser vazio")
                .IsNotNullOrEmpty(Country, "Country", "País não pode ser vazio")
                .IsNotNullOrEmpty(ZipCode, "ZipCode", "CEP não pode ser vazio")
            );
        }
        
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}