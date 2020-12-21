using Bank.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.Commands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximos 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "FirstName", "O sobrenome deve conter no máximos 40 caracteres")
                .IsEmail(Email, "Email", "O e-mail é inválido") // Posso colocar o que eu quiser na property
                .IsNotNullOrEmpty(Password, "Password", "A senha não pode ser vazia")
                .IsNotNullOrEmpty(Document, "Dcument", "O documento não pode ser vazio.")
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
    }
}